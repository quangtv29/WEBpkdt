using API.Database;
using API.DTOs.AccountDTO;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;

        public AccountController(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO input)
        {
            var user = await _db.Account.AsNoTracking().FirstOrDefaultAsync(e => e.User == input.user && e.Password == input.password);
            if (user == null) return NotFound();
            var account = new Account
            {
                    User = user.User,
                Password = user.Password,
                Position = user.Position
            };
            var json = JsonSerializer.Serialize(new
            {
                status = "success",
                message = "Đăng nhập thành công",
                data = account
            });
            return Content(json, "application/json");
        }

        [HttpPost("createAccount")]

        public async Task<IActionResult> createAccount(CreateDTO input)
        {

            //var account = new Account
            //{
            //    /*User = input.user,*/
            //    Password = input.password,
            //    Position = Position.Customer

            //};
            await _db.Account.AddAsync(_mapper.Map<Account>(input));
            await _db.SaveChangesAsync();
            return new JsonResult("Done");
        }

        [HttpDelete("delete")]

       

        [HttpPut("put")]

        public async Task<IActionResult> Update (Account input)
        {
           
            var accountid = await _db.Account.FindAsync(input.Id);
            if (accountid != null)
            {
                accountid.User = input.User;
                accountid.Password = input.Password;
               
            }
           _db.Update(accountid);
           await _db.SaveChangesAsync();
            return Ok(accountid);
        }
    }
}
