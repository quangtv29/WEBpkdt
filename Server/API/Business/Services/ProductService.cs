﻿using API.Business.DTOs.ProductDTO.cs;
using API.Business.Helper;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using API.Exceptions.BadRequestExceptions;
using API.Exceptions.NotFoundExceptions;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;



        public ProductService(IRepositoryManager repo, IMapper mapper, IOptions<CloudinarySettings> config)
        {
            _repo = repo;
            _mapper = mapper;
            var account = new Account(
           "dimu08wco",
           "672165145915545",
          "8xiFHI16qD8YS2TYiZ3xNKmm108");

                    _cloudinary = new Cloudinary(account);
        }

        public async Task<Product> CreateProduct(CreateProductDTO product)
        {
            if (product == null) throw new ArgumentNullException();
            if (product.Image == null || product.Image.Length == 0)
            {
                throw new Exception("Không có ảnh");
            }
            var pro = _mapper.Map<Product>(product);
            string imagePath = await SaveImage(product.Image);
            pro.Image = imagePath;
            _repo.Product.CreateProduct(pro);
            await _repo.SaveAsync();
            return pro;
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

        public async Task<GetAllProductDTO> GetProductById(Guid? Id)
        {
            var result = await (from pd in _repo.Product.GetAll(false)
                                join fb in _repo.Feedback.GetAll(false) on pd.Id equals fb.ProductId
                                into feedbackGroup
                                from fb in feedbackGroup.DefaultIfEmpty()
                                where pd.Id == Id
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
                                }).FirstOrDefaultAsync();
            return result;
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

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            var publicId = Guid.NewGuid().ToString();

          
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                PublicId = publicId
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

          
            var imageUrl = uploadResult.SecureUrl.ToString();

            return imageUrl;
        }

        public async Task Update(UpdateProductDTO product, Guid? Id)
        {
            var products =  await _repo.Product.GetProductById(Id) ?? 
                throw new ProductNotFoundException(Id);
                _mapper.Map(product, products);
             await  _repo.SaveAsync();
        }
        public async Task<IEnumerable<Product>> getProductByProductTypeId(Guid? ProductTypeId, ProductParameters productParameters)
        {
            var result = await _repo.Product.getProductByProductTypeId(ProductTypeId, productParameters);
            return result;
        }
    }
}
