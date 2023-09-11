using API.Business.DTOs.ProductDTO.cs;
using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using API.Exceptions.NotFoundExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace API.Business.Repository
{
    public class ProductRepository :  RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DataContext db) : base(db)
        {
        }

        public  void delete(Product product)
        {
             Delete(product);

        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
           var products =  await GetAll(false).Where(p=>p.isDelete == false).ToListAsync();
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

      
    }
}
