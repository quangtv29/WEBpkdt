using API.Business.DTOs.SaleDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface ISaleService
    {
        Task<double?> getMoney(string discountCode, int? totalMoney);

        Task<Sale> createSale(CreateDiscountCode discount);
    }
}
