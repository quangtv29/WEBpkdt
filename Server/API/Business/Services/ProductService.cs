using API.Business.DTOs.ProductDTO.cs;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using API.Exceptions.BadRequestExceptions;
using API.Exceptions.NotFoundExceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<GetAllProductDTO>> GetAll(ProductParameters productParameters)
        {
            var result = await (from pd in _repo.Product.GetAll(false)
                          join fb in _repo.Feedback.GetAll(false) on pd.Id equals fb.ProductId
                          into feedbackGroup
                          from fb in feedbackGroup.DefaultIfEmpty()
                          group fb by new
                          {
                              pd.Id,
                              pd.Name,
                              pd.Quantity,
                              pd.ImportPrice,
                              pd.Price,
                              pd.ProductTypeID,
                              pd.Producer,
                              pd.Describe,
                              pd.Image,
                              pd.Sold
                          } into g
                          select new GetAllProductDTO
                          {
                              Id = g.Key.Id,
                              Name = g.Key.Name,
                              Quantity = g.Key.Quantity,
                              ImportPrice = g.Key.ImportPrice,
                              Price = g.Key.Price,
                              ProductTypeID = g.Key.ProductTypeID,
                              Producer = g.Key.Producer,
                              Describe = g.Key.Describe,
                              Image = g.Key.Image,
                              Sold = g.Key.Sold,
                              StarRating = g.Sum(f => f.Star) / (double)g.Count()
                          }).Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();
            return result;

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
