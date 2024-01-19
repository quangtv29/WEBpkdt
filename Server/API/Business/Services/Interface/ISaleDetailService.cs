using API.Business.DTOs.SaleDetailDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface ISaleDetailService
    {
        Task<double?> getMoney(string discount, string id, double totalMoney);
        Task<SaleDetail> createSaleDetail(CreateSaleDetailDTO saleDetail);
        Task<SaleDetail> check(Guid? SaleId, string? customerId);
        Task<SaleDetail> updateSaleDetail(string discount, string id);
    }
}
