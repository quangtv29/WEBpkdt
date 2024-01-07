using API.Business.DTOs.BillDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using API.Entities.Enum;
using API.Exceptions.NotFoundExceptions;
using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace API.Business.Services
{
    public sealed class BillService : IBillService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;



        public BillService(IRepositoryManager repo, IMapper mapper, IConfiguration configuration)
        {
            _repo = repo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<Bill> createBill(CreateBillDTO bill, string code)
        {
            var bills =  _mapper.Map<Bill>(bill);
            if (code == null)
            {
                bills.Discount = 0;
                bills.IntoMoney = bills.TotalMoney;
                _repo.Bill.createBill(bills);
                await _repo.SaveAsync();
                return bills;
            }
            else
            {
                var sale = await _repo.Sale.GetSaleByCode(code);
                if (sale == null)
                {
                    return null;
                }
                double? discount = 0;
                if (bills.TotalMoney > sale.MinBill)
                {
                    discount = bills.TotalMoney * sale.Percent > sale.Money
                       ? sale.Money
                       : bills.TotalMoney * sale.Percent;
                }
                if (sale.Count < sale.Quantity)
                {
                    bills.Discount = discount;
                    bills.IntoMoney = bills.TotalMoney - discount >= 0
                        ? bills.TotalMoney - discount
                        : 0;

                    sale.Count += 1;
                    _repo.Bill.createBill(bills);
                    await _repo.SaveAsync();
                    return bills;   
                }
                return new Bill { };
            }
        }

        public async Task<(IEnumerable<Bill>,int a)> GetAll(bool trackChanges, Status status, BillParameters billParameters)
        {
            var bill = await  _repo.Bill.GetAllBill(trackChanges,status,billParameters);
             int a = await _repo.Bill.GetAllByCondition(p => p.Status == status, false).Where(p => p.isDelete == false)
                .CountAsync();
                return (bill,a);
        }

        

        public async Task<IEnumerable<Bill>> GetAllBillFromCustomer(string? customerId, bool trackChanges, Status status)
        {
            var customer = await _repo.Customer.GetCustomerByCondition(p => p.Id == customerId, trackChanges);

            if (customer == null || !customer.Any())
            {
                throw new CustomerNotFoundException(customerId);
            }
                var bill = await _repo.Bill.GetAllBillFromCustomer(customerId, trackChanges, status);  
          
            return bill;
        }

        public async Task<GetAllBillDTO> getBillById(Guid? Id)
        {
            var result = await _repo.Bill.getBillById(Id,false);
            return _mapper.Map<GetAllBillDTO>(result);
        }

        public async Task<Bill> updateStatusBill (Guid? Id, Status status)
        {
            var result = await _repo.Bill.getBillById(Id,true);
            result.Status = status;
            if (status == 0)
            {
                result.ShippingDate = DateTime.Now;
                result.FormatShippingDate = result.ShippingDate.ToString("dd/MM/yyyy HH:mm");
                var order = await _repo.OrderDetail.GetOrderDetailByBillID(Id);
                foreach (var od in order)
                {
                    var pro = await _repo.Product.GetProductById(od.ProductId);
                    pro.Sold += od.Quantity;
                }
            }
           if (status == Status.Canceled)
            {

                var order = await _repo.OrderDetail.GetOrderDetailByBillID(result.Id);
                foreach(var od in order)
                {
                    var product = await _repo.Product.GetProductById(od.ProductId);
                    product.Quantity += od.Quantity;
                }    
                 
            }    
            
            await _repo.SaveAsync();
            return result;
        }

        public async Task<GetInfoOrderDTO> getInfoOrder(string? Id)
        {
            var result = await _repo.Bill.GetAllByCondition(p => p.CustomerID == Id, false)
                 .Where(p => p.isDelete == false && p.Status == 0).ToListAsync();
            int countDone = await _repo.Bill.GetAllByCondition(p => p.CustomerID == Id, false)
                .Where(p => p.isDelete == false && p.Status == 0).CountAsync();
            int countCancel = await _repo.Bill.GetAllByCondition(p => p.CustomerID == Id, false)
                .Where(p => p.isDelete == false && p.Status == Status.Canceled).CountAsync();
            double? totalDiscount = 0;
            var thirtyDaysAgo = DateTime.Now;
            var results = await _repo.Bill.GetAllByCondition(p => p.CustomerID == Id, false)
                 .Where(p => p.isDelete == false && p.Status == 0 && p.Time.Month == thirtyDaysAgo.Month).ToListAsync();

            int? totalOrder = 0;
            int? totalOrderOfMonth = 0;
            foreach ( var re in result)
            {
                totalOrder += re.TotalMoney;
                totalDiscount += re.Discount;
            }
            foreach (var re in results)
            {
                totalOrderOfMonth += re.TotalMoney;
            }
            return new GetInfoOrderDTO { 
              Quantity = countDone,
              TotalOrder = totalOrder,
              TotalDiscount = totalDiscount,
              TotalOrderofMonth = totalOrderOfMonth,
              QuantityCancel=countCancel
            };
        }

        public async Task<Bill> updateBillById(UpdateBillDTO bill)
        {
            try
            {
                var bills = await _repo.Bill.updateBillById(bill.Id);
                bills.Discount = bill.Discount;
                bills.IntoMoney = bill.IntoMoney;
                bills.Address = bill.Address;
                bills.PhoneNumber = bill.PhoneNumber;
                bills.Status = bill.status;
                bills.Name = bill.Name;
               
                await _repo.SaveAsync();
                return bills;
            }
            catch 
            {
                return new Bill { };
            }
        }

        public async Task<List<Revenue>> TotalRevenueLast12Months()
        {
            var result = await _repo.Bill.TotalRevenueLast12Months();
            return result;
        }

        public async Task<IEnumerable<Statistical>> statisticalProduct (DateTime a)
        {
            var result = await (from bill in _repo.Bill.GetAll(false)
                                join or in _repo.OrderDetail.GetAll(false) on bill.Id equals or.BillId
                                join pd in _repo.Product.GetAll(false) on or.ProductId equals pd.Id
                                where bill.Status == Status.Done 
                                && a.Month == bill.Time.Month
                                && a.Year == bill.Time.Year
                                group new { pd, or } by new { pd.Name, or.Price } into groupedProducts
                                select new Statistical
                                {
                                    Name = groupedProducts.Key.Name,
                                    Quantity = groupedProducts.Sum(p=>p.or.Quantity) * groupedProducts.Key.Price,
                                }
                                
                ).OrderByDescending(p=>p.Quantity)
                .Take(5)
                .ToListAsync();
            return result;
        }

        public async Task<string> payVNPay (CreateVNPayDTO vnpay)
        {
            var config = _configuration.GetSection("VnPayPaymentConfig:Create").Get<CreateVnPayPaymentConfigDto>();
            var url = _configuration.GetSection("VnPayPaymentConfig:ApiUrl").Get<string>();

            var queryStringDictionary = new Dictionary<string, string>();
            queryStringDictionary.Add("vnp_Version", config.Version);
            queryStringDictionary.Add("vnp_Command", config.Command);
            queryStringDictionary.Add("vnp_TmnCode", config.TmnCode);
            queryStringDictionary.Add("vnp_Amount", (vnpay.Amount * 100).ToString());
            queryStringDictionary.Add("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            queryStringDictionary.Add("vnp_CurrCode", config.CurrCode);
            queryStringDictionary.Add("vnp_IpAddr", config.IpAddr);
            queryStringDictionary.Add("vnp_Locale", config.Locale);
            queryStringDictionary.Add("vnp_OrderInfo", $"Thanh toan don hang tri gia: {vnpay.Amount}");
            queryStringDictionary.Add("vnp_OrderType", "170000");
            queryStringDictionary.Add("vnp_ReturnUrl", vnpay.CallBackUrl);
            queryStringDictionary.Add("vnp_TxnRef", DateTime.Now.ToString("yyyyMMddHHmmss"));

            queryStringDictionary = queryStringDictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, v => v.Value);

            var listParam = new List<string>();
            foreach (var item in queryStringDictionary)
            {
                if (!string.IsNullOrEmpty(item.Value))
                    listParam.Add($"{item.Key}={WebUtility.UrlEncode(item.Value)}");//UrlPathEncode, UrlEncode 
            }
            var signData = String.Join("&", listParam);
            //signData = HttpUtility.UrlPathEncode(signData);
            var hashData = HMACSHA512(signData, config.HashSecret);

            var endpoint = $"{url}?{signData}&vnp_SecureHash={hashData}";
            return endpoint;
        }
        public  string HMACSHA512(string raw, string key)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(raw);
            HMACSHA512 hash = new HMACSHA512(keyByte);
            byte[] hashmessage = hash.ComputeHash(messageBytes);
            return ByteToString(hashmessage).ToLower();
        }
        public  string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }

            return (sbinary);
        }

        public async Task<Bill> updatePayDone(Guid? Id)
        {
            var bill = await _repo.Bill.getBillById(Id, true);
            if (bill != null)
            {
                bill.DiscountCode = "Done";
                bill.Status = Status.Ordered;
            }
            await _repo.SaveAsync();
            return bill;
        }
    }
}
