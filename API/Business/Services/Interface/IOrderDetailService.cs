using API.Business.DTOs.OrderDetailDTO;
using API.Entities;
using System.Collections;

namespace API.Business.Services.Interface
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<GetAllOrderDetail>> GetAll(bool trackChanges);

        Task<IEnumerable<OrderDetail>> GetOrderDetailFromCustomerId(string? customerId);

        Task<int?> UpdateTotalMoneyDTO ( Guid? Id, int? Quantity);

        Task<OrderDetail> GetOrderDetailById(Guid? Id);
        Task<IEnumerable<PurchaseHistoryDTO>> purchaseHistory(string? CustomerId);

        Task<GetAllOrderDetail> createCart(CreateCartDTO orderDetail);

        Task<GetAllOrderDetail> updateOrderDetail(Guid? orderDetailId);

    }
}
