using API.Business.DTOs.ProductTypeDTO;
using API.Business.Repository;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Database;
using API.Entities;
using AutoMapper;

namespace API.Business.Services
{
    public class ProductTypeService :  IProductTypeService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public ProductTypeService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void createProductType(CreateProductTypeDTO productType)
        {
            var pro = _mapper.Map<ProductType>(productType);
            _repo._productTypeRepository.addProductType(pro);
            _repo.SaveAsync();
        }

        public async Task<IEnumerable<ProductType>> GetAll()
        {
          return await _repo._productTypeRepository.GetAll();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypeById(Guid? Id)
        {
            var productType = await _repo._productTypeRepository.GetProductTypeById(Id);
            return productType;
        }

        //public void updateProductType(UpdateProducTypeDTO producType, Guid? Id)
        //{
        //    var productType = _repo._productTypeRepository. 
        //    _mapper.Map<ProductType>(producType);
        //    _repo.SaveAsync();
        //}
    }
}
