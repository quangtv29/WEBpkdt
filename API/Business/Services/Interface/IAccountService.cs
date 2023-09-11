using API.DTOs.AccountDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IAccountService
    {
       Task<Account> Login(LoginDTO login);
    }
}
