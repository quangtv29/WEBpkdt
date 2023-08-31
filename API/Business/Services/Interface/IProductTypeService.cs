using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetAll();
    }
}
