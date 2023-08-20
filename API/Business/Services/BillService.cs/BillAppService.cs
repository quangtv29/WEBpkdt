using API.Business.DTOs.BillDTO;
using API.Business.Interfaces.IBillService;
using API.Business.Repository;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Services.BillService.cs
{
    public class BillAppService : IBillService
    {
        private readonly IRepository<Bill> _repo;
        private readonly IMapper _mapper;
        public BillAppService(IRepository<Bill> repo, IMapper mapper)
        {
           _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GetAllBillDTO>> GetAll()
        {
            var list = await _repo.GetAll().ToListAsync();
            return _mapper.Map<List<GetAllBillDTO>>(list);
        }
    }
}
