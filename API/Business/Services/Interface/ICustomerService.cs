using API.Entities;

namespace API.Business.Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomer(bool trackChanges);
    }
}
