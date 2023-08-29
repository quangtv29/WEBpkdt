using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Business.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext db) : base(db)
        {

        }

       

        public async Task<IEnumerable<Customer>> GetCustomerByCondition(Expression<Func<Customer, bool>> expression, bool trackChanges)
        {
            return await GetAllByCondition(expression, trackChanges).Where(c=>c.isDelete == false).ToListAsync();
        }

       public async Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges)
        {
            return await GetAll(trackChanges).OrderBy(c => c.Name).Where(c => c.isDelete == false).
               ToListAsync();
        }

        public async Task<Customer> addCustomer(Customer customer)
        {
            Create(customer);
            return customer;
        }
    }
}
