﻿using API.Business.DTOs.ProductTypeDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
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

        public async Task<ProductType> createProductType(CreateProductTypeDTO productType)
        {
            var pro = _mapper.Map<ProductType>(productType);
            _repo.ProductType.addProductType(pro);
          await  _repo.SaveAsync();
            return pro;
        }

        public async Task<IEnumerable<ProductType>> GetAll()
        {
          return await _repo.ProductType.GetAll();
        }

        public async Task<ProductType> GetProductTypeById(Guid? Id)
        {
            var productType = await _repo.ProductType.GetProductTypeById(Id);
            return productType;
        }

        public async Task updateProductType(UpdateProducTypeDTO producType, Guid? Id)
        {
            var productType = await _repo.ProductType.GetProductTypeById(Id);
            _mapper.Map(producType, productType);
           await _repo.SaveAsync();
        }
    }
}
