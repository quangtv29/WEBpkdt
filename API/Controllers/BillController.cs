using API.Business.DTOs.BillDTO;
using API.Database;
using API.Entities;
using API.Entities.Enum;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<GetAllBillDTO>> GetAll ()
        {
            var bill = await _db.Bill.AsNoTracking().ToListAsync();
            return _mapper.Map<List<GetAllBillDTO>>(bill);
        }



        [HttpPost("addBill")]

        public async Task<IActionResult> AddBill(CreateBillDTO input)
        {
            Bill bill = new Bill
            {
                Id = new Guid(),
                CustomerID = input.CustomerId,
                Time = DateTime.Now,
                Address = input.Address,
                PhoneNumber = input.PhoneNumber,
                Discount = input.Discount,
                TotalMoney = input.TotalMoney,
                Status = Status.Ordered,
                Note =  input.Note
            };

            await _db.AddAsync(_mapper.Map<Bill>(input));
            await _db.SaveChangesAsync();
            return new JsonResult("Done");
        }

    }
}
