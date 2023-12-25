using API.Business.DTOs;
using API.Business.DTOs.AccountDTO;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Business.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<bool> resetPassword(ResetPasswordDTO reset);
        Task<IdentityResult> CreateUser(CreateUserDTO user);

        Task<(bool,int)> Login(LoginValidateDTO login);
        Task<TokenDTO> CreateToken(bool populateExp);
        Task<TokenDTO> RefreshToken(TokenDTO tokenDto);

        Task<User> getInfo (string userId);
       Task<IEnumerable<string>> getRole(string UserId);
        Task<User> UpdateUser(string? userName, string? firstName, string? lastName);

        Task<int> isUserExists (string userId);
        Task<User> getInfoById(string? Id);

        

    }
}
