using API.Business.DTOs.ProductDTO.cs;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using API.Exceptions.BadRequestExceptions;
using API.Exceptions.NotFoundExceptions;
using AutoMapper;

namespace API.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task deleteProduct(Guid? Id)
        {
            var product = await _repo.Product.GetProductById(Id);
           _repo.Product.delete(product);
          await  _repo.SaveAsync();
        }

        public async Task<IEnumerable<Product>> GetAll(ProductParameters productParameters)
        {
           
            return await _repo.Product.GetAllProduct(productParameters); 

        }

        public async Task<Product> GetProductById(Guid? Id)
        {
           var product = await _repo.Product.GetProductById(Id) ??
                throw new ProductNotFoundException(Id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductByIds(IEnumerable<Guid>? Id)
        {
            if(Id == null)
            {
                throw new IdParametersBadRequestExceptions();
            }    
            var product = await _repo.Product.GetProductByIds(Id);
            return product;
        }

        public async Task Update(UpdateProductDTO product, Guid? Id)
        {
            var products =  await _repo.Product.GetProductById(Id) ?? 
                throw new ProductNotFoundException(Id);
                _mapper.Map(product, products);
            
             await  _repo.SaveAsync();
        }
    }
}
