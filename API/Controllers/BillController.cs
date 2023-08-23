using API.Business.DTOs.BillDTO;
using API.Business.Repository;
using API.Database;
using API.Entities;
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

        public BillController(DataContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
           
        }


        [HttpGet("getAll")]

        public async Task<IActionResult> GetAll ()
        {
            var bill = await _db.Bill.AsNoTracking().ToListAsync();
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
