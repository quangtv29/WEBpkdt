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


        

      

       

       
    }
}
