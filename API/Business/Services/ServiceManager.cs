using API.Business.Repository;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;

namespace API.Business.Services
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IBillService> _billservice;

        public ServiceManager(IRepositoryManager repositoryManager )
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager));
            _billservice = new Lazy<IBillService>(() => new BillService(repositoryManager));
        }

        public ICustomerService customerService => _customerService.Value;

        public IBillService billService => _billservice.Value;
    }
}
