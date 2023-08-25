using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using System.Linq.Expressions;


namespace API.Business.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext db) : base(db)
        {

        }

        public IEnumerable<Customer> GetAllCustomer(bool trackChanges)
        {
            return GetAll(trackChanges).OrderBy(c => c.Name).Where(c=>c.isDelete == false).
                ToList();
        }

        public IEnumerable<Customer> GetCustomerByCondition(Expression<Func<Customer, bool>> expression, bool trackChanges)
        {
            return GetAllByCondition(expression, trackChanges).Where(c=>c.isDelete == false).ToList();
        }
    }
}
