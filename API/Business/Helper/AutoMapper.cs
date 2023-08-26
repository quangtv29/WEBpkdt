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
            CreateMap<GetAllBillDTO, Bill>().ReverseMap();
            CreateMap<GetAllCustomerDTO, Customer>().ReverseMap();
        }
    }
}
