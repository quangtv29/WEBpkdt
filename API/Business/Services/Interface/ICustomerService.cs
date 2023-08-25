using API.Entities;

namespace API.Business.Services.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges);
       Task<IEnumerable<Customer>> GetCustomerByID(Guid ? Id,  bool trackChanges);
    }
}
