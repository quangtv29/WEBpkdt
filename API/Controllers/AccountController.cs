using API.Business.Helper;
using API.Business.Interfaces;
using API.Business.Services.Interface;
using API.DTOs.AccountDTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IServiceManager _service;
        private readonly IToken _token;

        public AccountController(IServiceManager service, IToken token)
        {
           _service = service;
            _token = token;
            
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO input)
        {
            var account = await _service.accountService.Login(input);
            if (account != null)
            {
                return Ok(new ApiResponse {
                    StatusCode = HttpStatusCode.OK,
                Message = "Login Success",
                Data = _token.CreateToken(account)
            });
               
            }

            return Ok(new ApiResponse
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = "Login Fail",
            });
        }


        

      

       

       
    }
}
