using API.Entities;
using System.Linq.Expressions;

namespace API.Business.Repository.IRepository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer(bool trackChanges);

        IEnumerable<Customer> GetCustomerByCondition(Expression<Func<Customer,bool>> expression, bool trackChanges);
    }
}
