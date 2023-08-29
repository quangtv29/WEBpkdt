using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
    }
}
