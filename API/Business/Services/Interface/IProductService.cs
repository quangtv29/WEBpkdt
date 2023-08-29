using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
