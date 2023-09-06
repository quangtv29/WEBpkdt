using API.Business.DTOs.OrderDetailDTO;
using API.Entities;
using System.Collections;

namespace API.Business.Services.Interface
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAll(bool trackChanges);

        Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerId(Guid? customerId);

        Task <OrderDetail> UpdateTotalMoneyDTO ( Guid? Id, int? Quantity);

        Task<OrderDetail> GetOrderDetailById(Guid? Id);
        Task<IEnumerable<PurchaseHistoryDTO>> purchaseHistory(Guid? CustomerId);

    }
}
