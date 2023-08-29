using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using System.Collections;
using System.Net;

namespace API.Business.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IRepositoryManager _repo;

        public OrderDetailService(IRepositoryManager repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<OrderDetail>> GetAll(bool trackChanges)
        {
            var orderDetail = await _repo._orderDetailRepository.GetAllOrderDetail(trackChanges);
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerId(Guid? customerId)
        {
            var bill = await _repo._billRepository.GetAllBillFromCustomer(customerId, false);
            var orderDetail = await _repo._orderDetailRepository.GetOrderDetailFromCustomerID(bill);
            return orderDetail;
        }
        
    }
}
