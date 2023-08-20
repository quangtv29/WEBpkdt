using API.Business.Interfaces.ICustomerService;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Business.Services.CustomerService
{
    public class CustomerAppService : ICustomerService
    {
        private readonly DataContext _db;
        public CustomerAppService(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Customer>> GetAll()
        {
            var list = await _db.Customer.AsNoTracking().ToListAsync();
            return list;
        }
    }
}
