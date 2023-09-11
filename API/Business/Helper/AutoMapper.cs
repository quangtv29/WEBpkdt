using API.Business.DTOs.BillDTO;
using API.Business.DTOs.CustomerDTO;
using API.Business.DTOs.OrderDetailDTO;
using API.Business.DTOs.ProductDTO.cs;
using API.Business.DTOs.ProductTypeDTO;
using API.DTOs.AccountDTO;
using API.Entities;
using AutoMapper;

namespace API.Business.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<LoginDTO, Account>().ReverseMap();
            CreateMap<CreateDTO, Account>().ReverseMap();
            CreateMap<CreateBillDTO, Bill>().ReverseMap();
            CreateMap<GetAllBillDTO, Bill>()
                .ForMember(b => b.ConvertDiscount, p => p.MapFrom(src => src.Discount))
                .ForMember(t => t.ConvertTotalMoney, p => p.MapFrom(src => src.TotalMoney))
                .ReverseMap();
            CreateMap<GetAllCustomerDTO, Customer>()
                .ForMember(p=> p.FormatDate, b=> b.MapFrom(src=> src.DateOfBirth) )
                .ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<GetAllProductDTO, Product>()
                .ForMember(p => p.formatImportPrice, o => o.MapFrom(src => src.ImportPrice))
                .ForMember(p => p.formatPrice, o => o.MapFrom(src => src.Price))
                .ReverseMap();
            CreateMap<GetAllOrderDetail, OrderDetail>().ReverseMap();
            CreateMap<PurchaseHistoryDTO, OrderDetail>().ReverseMap();
            CreateMap<CreateOrderDetailDTO, OrderDetail>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<CreateProductTypeDTO, ProductType>().ReverseMap();
            CreateMap<UpdateProducTypeDTO, ProductType>();
        }
    }
}
