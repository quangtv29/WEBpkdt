using API.Business.Repository.IRepository;
using API.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Business.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _db;
        private readonly Lazy<ICustomerRepository> _customerRepo;
        private readonly Lazy<IBillRepository> _billrepo;
        private readonly Lazy<IOrderDetailRepository> _orderDetailRepo;
        private readonly Lazy<IProductRepository> _productRepo;
        private readonly Lazy<IProductTypeRepository> _productTypeRepo;
        private readonly Lazy<ISaleRepository> _saleRepo;
        private readonly Lazy<IFeedbackRepository> _feedbackRepository;
        private readonly Lazy<INotificationRepository> _notificationsRepository;
        private readonly Lazy<ISaleDetailRepository> _saleDetailRepository;
        private readonly Lazy<IBlogRepository> _blogRepository;

        public RepositoryManager(DataContext db )
        {
            _db = db;
            _customerRepo = new Lazy<ICustomerRepository>(() => new CustomerRepository(db));
            _billrepo = new Lazy<IBillRepository>(() => new BillRepository(db));
            _orderDetailRepo = new Lazy<IOrderDetailRepository>(() => new OrderDetailRepository(db));
            _productRepo = new Lazy<IProductRepository>(() => new ProductRepository(db));
            _productTypeRepo = new Lazy<IProductTypeRepository>(()=> new ProductTypeRepository(db));
            _saleRepo = new Lazy<ISaleRepository>(() => new SaleRepository(db));
            _feedbackRepository = new Lazy<IFeedbackRepository>(() => new FeedbackRepository(db));
            _notificationsRepository = new Lazy<INotificationRepository>(() => new NotificationRepository(db));
            _saleDetailRepository = new Lazy<ISaleDetailRepository>(() => new SaleDetailRepository(db));
            _blogRepository = new Lazy<IBlogRepository>(() => new BlogRepository(db));
        }


        public ICustomerRepository Customer => _customerRepo.Value;

        public IBillRepository Bill => _billrepo.Value;

        public IOrderDetailRepository OrderDetail => _orderDetailRepo.Value;

        public IProductRepository Product => _productRepo.Value;

        public IProductTypeRepository ProductType => _productTypeRepo.Value;


        public ISaleRepository Sale => _saleRepo.Value;


        public IFeedbackRepository Feedback => _feedbackRepository.Value;

        public INotificationRepository Notification => _notificationsRepository.Value;

        public ISaleDetailRepository SaleDetail => _saleDetailRepository.Value;

        public IBlogRepository Blog => _blogRepository.Value;

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public IDbContextTransaction Transaction()
        {
           return _db.Database.BeginTransaction();    
        }
    }
}
