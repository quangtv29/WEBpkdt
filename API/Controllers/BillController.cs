using API.Business.DTOs.BillDTO;
using API.Business.Interfaces.IBillService;
using API.Business.Repository;
using API.Database;
using API.Entities;
using API.Entities.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.Controllers
{
    public class BillController : BaseApiController
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private readonly IBillService _service;

        public BillController(DataContext db,IMapper mapper,IBillService service)
        {
            _db = db;
            _mapper = mapper;
            _service = service;
        }


        [HttpGet("getAll")]

        public async Task<IActionResult> GetAll ()
        {
            var bill = await _service.GetAll();
            if (bill == null)
                return BadRequest(HttpStatusCode.NoContent);
           return Ok( _mapper.Map<List<GetAllBillDTO>>(bill));
            
        }



        [HttpPost("addBill")]

        public async Task<IActionResult> AddBill(CreateBillDTO input)
        {
            await _db.AddAsync(_mapper.Map<Bill>(input));
            await _db.SaveChangesAsync();
            return new JsonResult("Done");
        }

    }
}
