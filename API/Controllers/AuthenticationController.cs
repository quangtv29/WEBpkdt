using API.Business.DTOs;
using API.Business.DTOs.AccountDTO;
using API.Business.Helper;
using API.Business.Services.Interface;
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
            return StatusCode(201);
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
                Message = "Login Success"
            }) ;
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDTO tokenDto)
        {
            var tokenDtoToReturn = await
            _serviceManager.authenticationService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }
}
