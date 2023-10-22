using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;

namespace API.Business.Repository
{
    public class ProductListRepository : RepositoryBase<ProductList>, IProductListRepository
    {
        public ProductListRepository(DataContext db) : base(db)
        {
        }
    }
}
