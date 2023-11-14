using API.Business.DTOs;
using API.Business.DTOs.AccountDTO;
using API.Business.Helper;
using API.Business.Services.Interface;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    
    public class AuthenticationController : BaseApiController
    {
        public readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager )
        {
            _serviceManager = serviceManager;
             
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
            if (!result)
            {
                return Unauthorized( new ApiResponse
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "Login Fail"
                });
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
            var result = await _serviceManager.authenticationService.getInfoById(id);
            return Ok(result);
        }
    }
}
