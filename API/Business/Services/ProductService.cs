using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;

namespace API.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repo;

        public ProductService(IRepositoryManager repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var product = await _repo._productRepository.GetAllProduct();
            return product;
        }
    }
}
