using API.Business.DTOs.ProductDTO.cs;
using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProduct();

        Task<IEnumerable<Product>> GetProductByIds(IEnumerable<Guid>? Id);

        Task<Product> GetProductById(Guid? Id);
        void delete(Product product);

    }
}
