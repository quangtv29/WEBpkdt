using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;

namespace API.Business.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly  IRepositoryManager _repo;

        public CustomerService(IRepositoryManager repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer(bool trackChanges)
        {
             try
            {
                var customer = await _repo._customerRepository.GetAllCustomer(trackChanges);
                return customer;
            }
            catch 
            {

                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomerByID(Guid? Id, bool trackChanges)
        {
            var customer =  await _repo._customerRepository.GetCustomerByCondition(e=> e.Id == Id, trackChanges);
            return customer;
        }
    }
}
