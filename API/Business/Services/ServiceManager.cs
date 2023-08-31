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
        private readonly Lazy<IOrderDetailService> _orderDetailService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IProductTypeService> _productTypeService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper )
        {
            _mapper = mapper;
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, _mapper));
            _billservice = new Lazy<IBillService>(() => new BillService(repositoryManager));
            _orderDetailService = new Lazy<IOrderDetailService>(() => new OrderDetailService(repositoryManager,_mapper));
            _productService = new Lazy<IProductService> (() => new ProductService(repositoryManager,_mapper));
            _productTypeService = new Lazy<IProductTypeService>(() => new ProductTypeService(repositoryManager));
        }

        public ICustomerService customerService => _customerService.Value;

        public IBillService billService => _billservice.Value;

        public IOrderDetailService orderDetailService => _orderDetailService.Value;

        public IProductService productService => _productService.Value;

        public IProductTypeService productTypeService => _productTypeService.Value;
    }
}
