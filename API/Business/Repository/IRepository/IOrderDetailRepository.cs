using API.Business.DTOs.OrderDetailDTO;
using API.Entities;
using System.Collections;
using System.Linq.Expressions;

namespace API.Business.Repository.IRepository
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetail(bool trackChanges);
        Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerID(IEnumerable<Bill> bill);
    }
}
