using API.Entities;

namespace API.Business.Repository.IRepository 
{
    public interface ISaleRepository : IRepositoryBase<Sale>
    {
        Task<int?> GetMoney(string discountCode);
        Task<Sale> GetSaleByCode (string discountCode);

        void createSale(Sale discount);
    }
}
