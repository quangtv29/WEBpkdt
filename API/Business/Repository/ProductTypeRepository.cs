using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class ProductTypeRepository :RepositoryBase<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(DataContext db) : base(db)
        {
        }

        public async Task<IEnumerable<ProductType>> GetAll()
        {
             var productType = await GetAll(false).Where(p => p.isDelete == false).ToListAsync();
            return productType;
        }
    }
}
