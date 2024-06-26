﻿using API.Business.DTOs;
using API.Business.DTOs.AccountDTO;
using API.Business.Helper;
using API.Business.Services.Interface;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    
    public class AuthenticationController : BaseApiController
    {
        public readonly IServiceManager _serviceManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(IServiceManager serviceManager, SignInManager<User> signInManager)
        {
            _serviceManager = serviceManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser (CreateUserDTO user)
        {
            var result = await _serviceManager.authenticationService.CreateUser(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            var info = await _serviceManager.authenticationService.getInfo(user.UserName);
            return Ok(info);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login (LoginValidateDTO login)
        {
            var result = await _serviceManager.authenticationService.Login(login);
            if (result.Item1  == false)
            {
                return Unauthorized( new ApiResponse
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "Login Fail"
                });
            }
            else if (result.Item1 == true && result.Item2 == 0)
            {
                return Ok("Account has been looked");
            }    
            return Ok(new
            {
                StatusCode = HttpStatusCode.OK,
                Data = await _serviceManager.authenticationService.CreateToken(true),
                Message = "Login Success",
                User = await _serviceManager.authenticationService.getInfo(login.UserName),
                role = await _serviceManager.authenticationService.getRole(login.UserName)
        }) ;
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDTO tokenDto)
        {
            var tokenDtoToReturn = await
            _serviceManager.authenticationService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }

        [HttpPost("checkUserId")]

        public async Task<IActionResult> checkUserId ([FromBody] checkUser userId)
        {
            var result = await _serviceManager.authenticationService.isUserExists(userId.UserName);
            if (result == 0)
            {
                return Ok(new
                {
                    Data = 0,
                    Message = "Bạn cần nhập userId"
                });
            }    
            else if (result == 1)
            {
                return Ok(new
                {
                    Data = 1,
                    Message = "Success"
                });
            }    
            else
            {
                return Ok(new
                {
                    Data = -1,
                    Message = "UserId đã tồn tại"
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> getInfoById(string? id)
        {
            try
            {
                var result = await _serviceManager.authenticationService.getInfoById(id);
                if (result != null)
                {
                    result.FormatDate = result.CreateAccount.ToString("dd/MM/yyyy HH:mm:ss");
                }
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getInfoByName")]
        
        public async Task<IActionResult> getInfoByName(string? userName)
        {
            if (userName == null)
                return BadRequest();
            var result = await _serviceManager.authenticationService.getInfo(userName);
            return Ok(result);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("resetPassword")]
       public async Task<IActionResult> resetPassword(ResetPasswordDTO reset)
        {
            var result = await _serviceManager.authenticationService.resetPassword(reset);
            if (result)
            {
                return Ok("Done");
            }
            return BadRequest("Fail");
        }
    }
}
