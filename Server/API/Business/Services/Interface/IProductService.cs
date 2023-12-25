using API.Business.DTOs.ProductDTO.cs;
using API.Business.Shared;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<GetAllProductDTO>> GetAll(ProductParameters productParameters);

        Task<IEnumerable<Product>> GetProductByIds(IEnumerable<Guid>? Id);

        Task<GetAllProductDTO> GetProductById(Guid? Id);
        Task<IEnumerable<GetAllProductDTO>> getProductByProductType(string? productType, ProductParameters productParameters);

        Task Update(UpdateProductDTO product, Guid? Id);

        Task deleteProduct(Guid? Id);

        Task<Product> CreateProduct(CreateProductDTO product);

        Task<string> SaveImage(IFormFile imageFile);
         Task<IEnumerable<Product>> getProductByProductTypeId(Guid? ProductTypeId, ProductParameters productParameters);
        Task<(IEnumerable<GetAllProductDTO>, int)> searchByName(string name, ProductParameters productParameters);
        Task<Product> updateProduct( UpdateProductDTO product);
        Task<IEnumerable<GetAllProductDTO>> getProductByPrice(int? vip, int? to, ProductParameters productParameters, bool inStock, bool outOfStock);
        
        }
}
