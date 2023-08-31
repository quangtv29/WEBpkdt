using API.Business.DTOs.OrderDetailDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using System.Collections;
using System.Net;

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

        public async Task<IEnumerable<OrderDetail>> GetAll(bool trackChanges)
        {
            var orderDetail = await _repo._orderDetailRepository.GetAllOrderDetail(trackChanges);
            return orderDetail;
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


        public async Task<OrderDetail> UpdateTotalMoneyDTO(Guid? Id)
        {
            var orderDetails = await _repo._orderDetailRepository.GetOrderDetailById(Id);

            var product = await _repo._productRepository.GetProductById(orderDetails.ProductId);

            orderDetails.TotalMoney = product.Price * orderDetails.Quantity;
            orderDetails.LastModificationTime = DateTime.Now;
           await _repo.SaveAsync();
            return orderDetails;
        }
    }
}
