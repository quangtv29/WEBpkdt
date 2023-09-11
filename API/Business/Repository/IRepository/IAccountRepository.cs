
using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IAccountRepository
    {
        Task<Account> Login (Account Login);
    }
}
