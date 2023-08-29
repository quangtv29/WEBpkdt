using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class ProductRepository :  RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DataContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
           var products =  await GetAll(false).Where(p=>p.isDelete == false).ToListAsync();
            return products;
        }
    }
}
