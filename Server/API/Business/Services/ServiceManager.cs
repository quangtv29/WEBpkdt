using API.Business.Helper;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
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
        private readonly Lazy<INotificationService> _notificationService;
        private readonly Lazy<IBlogService> _blogService;
        private readonly Lazy<ISaleDetailService> _saleDetailService;
        private readonly Lazy<IPhotoService> _photoService;


        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IOptions<CloudinarySettings> config)
        {
            _mapper = mapper;
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, _mapper, config, configuration));
            _billservice = new Lazy<IBillService>(() => new BillService(repositoryManager, _mapper,configuration));
            _orderDetailService = new Lazy<IOrderDetailService>(() => new OrderDetailService(repositoryManager,_mapper));
            _productService = new Lazy<IProductService> (() => new ProductService(repositoryManager,_mapper, config, configuration));
            _productTypeService = new Lazy<IProductTypeService>(() => new ProductTypeService(repositoryManager,_mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_mapper, userManager,configuration,repositoryManager));
            _saleService = new Lazy<ISaleService>(() => new SaleService(repositoryManager,_mapper));
            _feedbackService = new Lazy<IFeedbackService>(() => new FeedbackService(repositoryManager, _mapper, config, configuration));
            _notificationService = new Lazy<INotificationService>(() => new NotificationService(repositoryManager, _mapper));
            _saleDetailService = new Lazy<ISaleDetailService>(() => new SaleDetailService(repositoryManager, _mapper));
            _blogService = new Lazy<IBlogService>(() => new BlogService(repositoryManager, _mapper,config,configuration));
            _photoService = new Lazy<IPhotoService>(() => new PhotoService(repositoryManager, configuration,_mapper));
        }

        public ICustomerService customerService => _customerService.Value;

        public IBillService billService => _billservice.Value;

        public IOrderDetailService orderDetailService => _orderDetailService.Value;

        public IProductService productService => _productService.Value;

        public IProductTypeService productTypeService => _productTypeService.Value;


        public IAuthenticationService authenticationService => _authenticationService.Value;

        public ISaleService saleService => _saleService.Value;

        public IFeedbackService feedbackService => _feedbackService.Value;

        public INotificationService notificationService => _notificationService.Value;

        public ISaleDetailService saleDetailService => _saleDetailService.Value;

        public IBlogService blogService => _blogService.Value;

        public IPhotoService photoService => _photoService.Value;
    }
}
