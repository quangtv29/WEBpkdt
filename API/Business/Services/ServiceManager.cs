using API.Business.Repository;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using LoggerService;

namespace API.Business.Services
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<ICustomerService> _customerService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager )
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, loggerManager));
        }

        public ICustomerService customerService => _customerService.Value;
    }
}
