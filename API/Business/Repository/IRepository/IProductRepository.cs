using API.Business.DTOs.ProductDTO.cs;
using API.Business.Shared;
using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProduct(ProductParameters productParameters);

        Task<IEnumerable<Product>> GetProductByIds(IEnumerable<Guid>? Id);

        Task<Product> GetProductById(Guid? Id);
        void delete(Product product);

    }
}
