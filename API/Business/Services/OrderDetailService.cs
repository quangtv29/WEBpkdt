using API.Business.DTOs.OrderDetailDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public OrderDetailService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllOrderDetail>> GetAll(bool trackChanges)
        {
            var orderDetail = await _repo.OrderDetail.GetAllOrderDetail(trackChanges);
            return _mapper.Map<List<GetAllOrderDetail>>(orderDetail);
        }

        public async Task<OrderDetail> GetOrderDetailById(Guid? Id)
        {
            var orderDetail = await _repo.OrderDetail.GetOrderDetailById(Id);
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerId(Guid? customerId)
        {
            var bill = await _repo.Bill.GetAllBillFromCustomer(customerId, false);
            var orderDetail = await _repo.OrderDetail.GetOrderDetailFromCustomerID(bill);
            return orderDetail;
        }


        public async Task<int?> UpdateTotalMoneyDTO(Guid? Id, int? Quantity )
        {
            var product = await _repo.Product.GetProductById(Id);
            int? quantityValue = Quantity ?? 1;
           return product.Price * quantityValue;
        }

        public async Task<IEnumerable<PurchaseHistoryDTO>> purchaseHistory (Guid? CustomerId)
        {
            var result =  await (from kh in _repo.Customer.GetAll(false)
                                join bill in _repo.Bill.GetAll(false) on  kh.Id equals bill.CustomerID 
                                join order in _repo.OrderDetail.GetAll(false) on bill.Id equals order.BillId 
                                join product in _repo.Product.GetAll(false) on order.ProductId equals product.Id 
                                where kh.Id == CustomerId
                                select new PurchaseHistoryDTO
                                {
                                    Id = order.Id,
                                    Quantity = order.Quantity,
                                    Product = product.Name,
                                    Price = Helper.Helper.ConvertToMoney(order.Price),
                                    ProductId = order.Id,
                                    Image = product.Image,
                                    TotalMoney = Helper.Helper.ConvertToMoney( order.TotalMoney),
                                    Time = bill.Time
                                }
                                
            ).ToListAsync();

            return result;
            //var bill = await _repo._billRepository.GetAllBillFromCustomer(CustomerId, false) 
            //    ?? throw new Exception($"Doesn' exists Bill by CustomerID = {CustomerId} ");
            //var orderDetail =  await _repo._orderDetailRepository.GetOrderDetailFromCustomerID(bill);
            //List<PurchaseHistoryDTO> purchaseHistoryDTO = new () ;
            //if (orderDetail != null)
            //{
            //    var productId =  orderDetail.Select(p => p.ProductId);
            //    var product = await _repo._productRepository.GetProductByIds(productId);
               
            //    var history = _mapper.Map<List<PurchaseHistoryDTO>>(orderDetail);
            //    if (product != null)
            //    {
            //        foreach (PurchaseHistoryDTO pur in history)
            //        {
            //            pur.Product = product.FirstOrDefault(c => c.Id == pur.ProductId)?.Name; 
            //            pur.Image = product.FirstOrDefault(c => c.Id == pur.ProductId)?.Image;
            //        }
            //        return history;
            //    }
            //}
            //return purchaseHistoryDTO.ToList();
        }

        public async Task createOrderDetail(CreateOrderDetailDTO orderDetail)
        {
            var product = await _repo.Product.GetProductById(orderDetail.ProductId);
            orderDetail.Price = product.Price;
            var order = _mapper.Map<OrderDetail>(orderDetail);
            _repo.OrderDetail.addOrderDetail(order);
             await _repo.SaveAsync();
        }
    }
}
