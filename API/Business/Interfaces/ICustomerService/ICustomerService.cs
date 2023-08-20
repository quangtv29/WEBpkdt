using API.Entities;

namespace API.Business.Interfaces.ICustomerService
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAll();   
    }
}
