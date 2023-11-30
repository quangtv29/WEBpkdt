using API.Business.Helper;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

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
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<ISaleService> _saleService;
        private readonly Lazy<IFeedbackService> _feedbackService;
       

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IOptions<CloudinarySettings> config)
        {
            _mapper = mapper;
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, _mapper));
            _billservice = new Lazy<IBillService>(() => new BillService(repositoryManager, _mapper));
            _orderDetailService = new Lazy<IOrderDetailService>(() => new OrderDetailService(repositoryManager,_mapper));
            _productService = new Lazy<IProductService> (() => new ProductService(repositoryManager,_mapper, config, configuration));
            _productTypeService = new Lazy<IProductTypeService>(() => new ProductTypeService(repositoryManager,_mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_mapper, userManager,configuration));
            _saleService = new Lazy<ISaleService>(() => new SaleService(repositoryManager,_mapper));
            _feedbackService = new Lazy<IFeedbackService>(() => new FeedbackService(repositoryManager, _mapper));
        }

        public ICustomerService customerService => _customerService.Value;

        public IBillService billService => _billservice.Value;

        public IOrderDetailService orderDetailService => _orderDetailService.Value;

        public IProductService productService => _productService.Value;

        public IProductTypeService productTypeService => _productTypeService.Value;


        public IAuthenticationService authenticationService => _authenticationService.Value;

        public ISaleService saleService => _saleService.Value;

        public IFeedbackService feedbackService => _feedbackService.Value;
    }
}
