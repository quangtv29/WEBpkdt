using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;

namespace API.Business.Repository
{
    public class SaleDetailRepository : RepositoryBase<SaleDetail>, ISaleDetailRepository
    {
        public SaleDetailRepository(DataContext db) : base(db)
        {
        }

        public void CreateSaleDetail (SaleDetail saleDetail)
        {
            Create(saleDetail);
        }
    }
}
