using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using LoggerService;

namespace API.Business.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly  IRepositoryManager _repo;
        private readonly ILoggerManager _logger;

        public CustomerService(IRepositoryManager repo, ILoggerManager logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public IEnumerable<Customer> GetAllCustomer(bool trackChanges)
        {
             try
            {
                var customer = _repo._customerRepository.GetAllCustomer(trackChanges);
                return customer;
            }
            catch 
            {

                throw;
            }
        }

        public IEnumerable<Customer> GetCustomerByID(Guid? Id, bool trackChanges)
        {
            var customer =   _repo._customerRepository.GetCustomerByCondition(e=> e.Id == Id, trackChanges);
            return customer;
        }
    }
}
