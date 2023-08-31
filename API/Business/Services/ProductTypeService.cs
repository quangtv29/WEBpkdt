using API.Business.Repository;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Database;
using API.Entities;

namespace API.Business.Services
{
    public class ProductTypeService :  IProductTypeService
    {
        private readonly IRepositoryManager _repo;

        public ProductTypeService(IRepositoryManager repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductType>> GetAll()
        {
          return await _repo._productTypeRepository.GetAll();
        }
    }
}
