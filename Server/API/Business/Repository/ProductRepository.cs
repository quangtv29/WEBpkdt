using API.Business.Repository.IRepository;
using API.Business.Shared;
using API.Database;
using API.Entities;
using API.Exceptions.NotFoundExceptions;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class ProductRepository :  RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DataContext db) : base(db)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public  void delete(Product product)
        {
             Delete(product);

        }

        public async Task<IEnumerable<Product>> GetAllProduct(ProductParameters productParameters)
        {
           var products =  await GetAll(false).Where(p=>p.isDelete == false)
                .Skip((productParameters.PageNumber - 1)* productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> getByTopSeller(ProductParameters productParameters)
        {
            var products = await GetAll(false).Where(p => p.isDelete == false)
                .OrderBy(p=>p.Sold)
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(Guid? Id)
        {
            var product = await GetAllByCondition(p => p.Id == Id, true).Where(p => p.isDelete == false).FirstOrDefaultAsync() 
                ?? throw new ProductNotFoundException(Id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductByIds(IEnumerable<Guid>? Id)
        {
            if (Id == null)
            {
                throw new Exception("Id is null");
            }    
           var product = await GetAllByCondition(p => Id.Contains(p.Id), false).Where(p => p.isDelete == false).ToListAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> getProductByProductTypeId(Guid? ProductTypeId, ProductParameters productParameters)
        {
            var results = await GetAllByCondition(p => p.ProductTypeID == ProductTypeId, false)
                 .Where(p => p.isDelete == false)
                 .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                 .Take(productParameters.PageSize)
                 .ToListAsync();
            return results;
        }
    }
}
