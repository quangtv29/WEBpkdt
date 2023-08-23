using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using System.Reflection.Metadata.Ecma335;

namespace API.Business.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        public CustomerRepository(DataContext db) : base(db)
        {

        }

        public IEnumerable<Customer> GetAllCustomer(bool trackChanges)
        {
            return GetAll(trackChanges).OrderBy(c => c.Name).
                ToList();
        }
            
        
    }
}
