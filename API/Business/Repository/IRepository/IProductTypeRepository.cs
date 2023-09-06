using API.Business.DTOs.ProductTypeDTO;
using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IProductTypeRepository
    {
           Task<IEnumerable<ProductType>> GetAll();
           
        Task<IEnumerable<ProductType>> GetProductTypeById(Guid? Id);
        void addProductType(ProductType productTypeDTO);
    }
}
