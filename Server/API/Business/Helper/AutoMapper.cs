﻿using API.Business.DTOs.AccountDTO;
using API.Business.DTOs.BillDTO;
using API.Business.DTOs.CustomerDTO;
using API.Business.DTOs.OrderDetailDTO;
using API.Business.DTOs.ProductDTO.cs;
using API.Business.DTOs.ProductTypeDTO;
using API.Business.DTOs.SaleDTO;
using API.Entities;
using AutoMapper;

namespace API.Business.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            
            CreateMap<CreateBillDTO, Bill>().ReverseMap();
            CreateMap<GetAllBillDTO, Bill>().ReverseMap();
            CreateMap<GetAllCustomerDTO, Customer>()
                .ForMember(p=> p.FormatDate, b=> b.MapFrom(src=> src.DateOfBirth) )
                .ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<GetAllProductDTO, Product>().ReverseMap();
            CreateMap<GetAllOrderDetail, OrderDetail>().ReverseMap();
            CreateMap<PurchaseHistoryDTO, OrderDetail>().ReverseMap();
            CreateMap<CreateOrderDetailDTO, OrderDetail>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<CreateProductTypeDTO, ProductType>().ReverseMap();
            CreateMap<UpdateProducTypeDTO, ProductType>();
            CreateMap<CreateUserDTO,User>().ReverseMap();
            CreateMap<CreateDiscountCode,Sale>().ReverseMap();    
        }
    }
}
