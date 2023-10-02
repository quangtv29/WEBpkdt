using API.Business.DTOs.OrderDetailDTO;
using API.Entities;
using System.Collections;
using System.Linq.Expressions;

namespace API.Business.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetail(bool trackChanges);
        Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerID(IEnumerable<Bill> bill);
        void Update(OrderDetail orderDetail);

        Task<OrderDetail> GetOrderDetailById(Guid? Id);

         void addOrderDetail (OrderDetail orderDetail);
    }
}
