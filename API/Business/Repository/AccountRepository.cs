using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(DataContext db) : base(db)
        {

        }

        public async Task<Account> Login(Account Login)
        {
            return await GetAllByCondition(p => p.User == Login.User && p.Password == Login.Password, false).Where(p => p.isDelete == false)
                .FirstOrDefaultAsync() ;
        }
    }
}
