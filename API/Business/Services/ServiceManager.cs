using API.Business.Repository;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using AutoMapper;

namespace API.Business.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly IMapper _mapper;
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IBillService> _billservice;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper )
        {
            _mapper = mapper;
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, _mapper));
            _billservice = new Lazy<IBillService>(() => new BillService(repositoryManager));
        }

        public ICustomerService customerService => _customerService.Value;

        public IBillService billService => _billservice.Value;
    }
}
