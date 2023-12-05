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
        Task<IEnumerable<PurchaseHistoryDTO>> listCart(string? CustomerId);

        Task<GetAllOrderDetail> createCart(CreateCartDTO orderDetail);

        Task<IEnumerable<OrderDetail>> updateOrderDetail(Guid? orderDetailId, string? isCart);
        Task<OrderDetail> updateOrderDetailBillId(Guid? orderDetailId, Guid? BillId);
        
        Task<GetAllOrderDetail> updateTotal (Guid? Id,  int? quantity);
        Task<IEnumerable<GetAllOrderDetail>> getOrderDetailByBillId(Guid? Id);
        Task<CountCartDTO> countCart(string? customerId);
        Task<IEnumerable<double?>> totalProfit();

    }
}
