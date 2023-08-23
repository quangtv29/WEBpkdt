using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer(bool trackChanges);
    }
}
