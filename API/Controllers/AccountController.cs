using API.Business.Helper;
using API.Business.Interfaces;
using API.Business.Services.Interface;
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
            ApiResponse response = new ApiResponse();
            if (account != null)
            {
                response.Message = "Login Success";
                response.Data = _token.CreateToken(account);
            };
            return Ok(response);
        }


        

      

       

       
    }
}
