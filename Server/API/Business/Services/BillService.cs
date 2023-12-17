using API.Business.DTOs.BillDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using API.Entities.Enum;
using API.Exceptions.NotFoundExceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Services
{
    public sealed class BillService : IBillService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;


        public BillService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        public async Task<IEnumerable<Bill>> GetAll(bool trackChanges, Status status, BillParameters billParameters)
        {
            var bill = await  _repo.Bill.GetAllBill(trackChanges,status,billParameters);
                return bill;
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
                var order = await _repo.OrderDetail.GetOrderDetailByBillID(Id);
                foreach (var od in order)
                {
                    var pro = await _repo.Product.GetProductById(od.ProductId);
                    pro.Sold += 1;
                }
            }
            await _repo.SaveAsync();
            return result;
        }

        public async Task<GetInfoOrderDTO> getInfoOrder(string? Id)
        {
            var result = await _repo.Bill.GetAllByCondition(p => p.CustomerID == Id, false)
                 .Where(p => p.isDelete == false && p.Status == 0).ToListAsync();
            int count = await _repo.Bill.GetAllByCondition(p => p.CustomerID == Id, false)
                .Where(p => p.isDelete == false && p.Status == 0).CountAsync();
            double? totalDiscount = 0;
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);
            var results = await _repo.Bill.GetAllByCondition(p => p.CustomerID == Id, false)
                 .Where(p => p.isDelete == false && p.Status == 0 && p.Time > thirtyDaysAgo).ToListAsync();

            int? totalOrder = 0;
            int? totalOrderOfMonth = 0;
            foreach ( var re in result)
            {
                totalOrder += re.TotalMoney;
                totalDiscount += re.Discount;
            }
            foreach (var re in result)
            {
                totalOrderOfMonth += re.TotalMoney;
            }
            return new GetInfoOrderDTO { 
              Quantity = count,
              TotalOrder = totalOrder,
              TotalDiscount = totalDiscount,
              TotalOrderofMonth = totalOrderOfMonth
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

        
    }
}
