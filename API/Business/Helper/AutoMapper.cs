using API.Business.DTOs.BillDTO;
using API.Business.DTOs.CustomerDTO;
using API.DTOs.AccountDTO;
using API.Entities;
using AutoMapper;

namespace API.Business.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateDTO, Account>().ReverseMap();
            CreateMap<CreateBillDTO, Bill>().ReverseMap();
            CreateMap<GetAllBillDTO, Bill>()
                .ForMember(b => b.ConvertDiscount, p => p.MapFrom(src => src.Discount))
                .ForMember(t => t.ConvertTotalMoney, p => p.MapFrom(src => src.TotalMoney))
                .ReverseMap();
            CreateMap<GetAllCustomerDTO, Customer>()
                .ForMember(p=> p.FormatDate, b=> b.MapFrom(src=> src.DateOfBirth) )
                .ReverseMap();
        }
    }
}
