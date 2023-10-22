using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class SaleRepository :  RepositoryBase<Sale>, ISaleRepository
    {
        public SaleRepository(DataContext db) : base(db)
        {
        }
        private Sale? sale2 { get; set; }
        public void createSale(Sale discount)
        {
            Create(discount);
        }

        public async Task<int?> GetMoney(string discountCode)
        {
            var money = await GetAllByCondition(p => p.DiscountCode == discountCode, false).Where(p => p.isDelete == false && p.EndDate > DateTime.Now).FirstOrDefaultAsync();
            if (money == null)
                return 0;
            return money.Money;
        }

        public async Task<Sale> GetSaleByCode(string discountCode)
        {
           var sale = await GetAllByCondition(p=>p.DiscountCode == discountCode,true)
                .Where(p=>p.isDelete==false && p.EndDate > DateTime.Now)
                .FirstOrDefaultAsync();
            return sale;
        }
    }
}
