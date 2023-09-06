using API.Business.DTOs.ProductTypeDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetAll();

        Task<IEnumerable<ProductType>> GetProductTypeById(Guid? Id);
        void createProductType(CreateProductTypeDTO productType);

        //void updateProductType(UpdateProducTypeDTO producType, Guid? Id);
    }
}
