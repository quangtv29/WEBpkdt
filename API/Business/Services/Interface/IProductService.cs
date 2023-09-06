using API.Business.DTOs.ProductDTO.cs;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();

        Task<IEnumerable<Product>> GetProductByIds(IEnumerable<Guid>? Id);

        Task<Product> GetProductById(Guid? Id);

        Task Update(UpdateProductDTO product, Guid? Id);

        Task deleteProduct(Guid? Id);
    }
}
