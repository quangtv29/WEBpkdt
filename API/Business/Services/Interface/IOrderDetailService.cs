using API.Business.DTOs.OrderDetailDTO;
using API.Entities;
using System.Collections;

namespace API.Business.Services.Interface
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAll(bool trackChanges);

        Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerId(Guid? customerId);

    }
}
