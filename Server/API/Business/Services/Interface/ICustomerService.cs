using API.Business.DTOs.CustomerDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges);
       Task<IEnumerable<Customer>> GetCustomerByID(string ? Id,  bool trackChanges);
        Task<Customer> addCustomer(CreateCustomerDTO customer);
        Task<Customer> updateCustomer(string? Id, UpdateCustomerDTO update);
        Task<Customer> addAvatar(IFormFile Image, string? CustomerId);
        Task<Customer> getCustomerByIDD(string? Id);
        Task<Customer> lockAccount(string? id);
    }
}
