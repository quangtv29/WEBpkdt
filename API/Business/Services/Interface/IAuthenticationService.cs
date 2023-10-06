using API.Business.DTOs.AccountDTO;
using Microsoft.AspNetCore.Identity;

namespace API.Business.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> CreateUser(CreateUserDTO user);

        Task<bool> Login(LoginValidateDTO login);
        Task<string> CreateToken();
    }
}
