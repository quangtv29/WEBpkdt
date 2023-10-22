using API.Entities;
using System.Linq.Expressions;

namespace API.Business.Repository.IRepository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges);

        Task<IEnumerable<Customer>> GetCustomerByCondition(Expression<Func<Customer,bool>> expression, bool trackChanges);

       void addCustomer (Customer customer);
    }
}
