using API.Business.DTOs.OrderDetailDTO;
using API.Entities;
using System.Collections;

namespace API.Business.Services.Interface
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<GetAllOrderDetail>> GetAll(bool trackChanges);

        Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerId(Guid? customerId);

        Task<int?> UpdateTotalMoneyDTO ( Guid? Id, int? Quantity);

        Task<OrderDetail> GetOrderDetailById(Guid? Id);
        Task<IEnumerable<PurchaseHistoryDTO>> purchaseHistory(Guid? CustomerId);

       Task createOrderDetail (CreateOrderDetailDTO orderDetail);

    }
}
