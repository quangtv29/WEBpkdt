using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IProductTypeRepository : IRepositoryBase<ProductType>
    {
           Task<IEnumerable<ProductType>> GetAll();
           
        Task<ProductType> GetProductTypeById(Guid? Id);
        void addProductType(ProductType productTypeDTO);
        
    }
}
