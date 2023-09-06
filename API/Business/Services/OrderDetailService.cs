using API.Business.DTOs.OrderDetailDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using System.Net.WebSockets;

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
            var orderDetail = await _repo._orderDetailRepository.GetAllOrderDetail(trackChanges);
            return _mapper.Map<List<GetAllOrderDetail>>(orderDetail);
        }

        public async Task<OrderDetail> GetOrderDetailById(Guid? Id)
        {
            var orderDetail = await _repo._orderDetailRepository.GetOrderDetailById(Id);
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerId(Guid? customerId)
        {
            var bill = await _repo._billRepository.GetAllBillFromCustomer(customerId, false);
            var orderDetail = await _repo._orderDetailRepository.GetOrderDetailFromCustomerID(bill);
            return orderDetail;
        }


        public async Task<int?> UpdateTotalMoneyDTO(Guid? Id, int? Quantity )
        {
            var product = await _repo._productRepository.GetProductById(Id);
            int? quantityValue = Quantity ?? 1;
           return product.Price * quantityValue;
        }

        public async Task<IEnumerable<PurchaseHistoryDTO>> purchaseHistory (Guid? CustomerId)
        {
            var bill = await _repo._billRepository.GetAllBillFromCustomer(CustomerId, false) 
                ?? throw new Exception($"Doesn' exists Bill by CustomerID = {CustomerId} ");
            var orderDetail =  await _repo._orderDetailRepository.GetOrderDetailFromCustomerID(bill);
            List<PurchaseHistoryDTO> purchaseHistoryDTO = new () ;
            if (orderDetail != null)
            {
                var productId =  orderDetail.Select(p => p.ProductId);
                var product = await _repo._productRepository.GetProductByIds(productId);
               
                var history = _mapper.Map<List<PurchaseHistoryDTO>>(orderDetail);
                if (product != null)
                {
                    foreach (PurchaseHistoryDTO pur in history)
                    {
                        pur.Product = product.FirstOrDefault(c => c.Id == pur.ProductId)?.Name; 
                        pur.Image = product.FirstOrDefault(c => c.Id == pur.ProductId)?.Image;
                    }
                    return history;
                }
            }
            return purchaseHistoryDTO.ToList();
        }

        public async Task createOrderDetail(CreateOrderDetailDTO orderDetail)
        {
            var product = await _repo._productRepository.GetProductById(orderDetail.ProductId);
            orderDetail.Price = product.Price;
            var order = _mapper.Map<OrderDetail>(orderDetail);
            _repo._orderDetailRepository.addOrderDetail(order);
             await _repo.SaveAsync();
        }
    }
}
