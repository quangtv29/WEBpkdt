using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IProductTypeRepository
    {
           Task<IEnumerable<ProductType>> GetAll();

    }
}
