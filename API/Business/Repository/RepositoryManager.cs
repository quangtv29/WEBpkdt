using API.Business.Repository.IRepository;
using API.Database;
using System.Runtime.InteropServices;

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
        private readonly Lazy<IAccountRepository> _accountRepo;
        public RepositoryManager(DataContext db )
        {
            _db = db;
            _customerRepo = new Lazy<ICustomerRepository>(() => new CustomerRepository(db));
            _billrepo = new Lazy<IBillRepository>(() => new BillRepository(db));
            _orderDetailRepo = new Lazy<IOrderDetailRepository>(() => new OrderDetailRepository(db));
            _productRepo = new Lazy<IProductRepository>(() => new ProductRepository(db));
            _productTypeRepo = new Lazy<IProductTypeRepository>(()=> new ProductTypeRepository(db));
            _accountRepo = new Lazy<IAccountRepository>(() => new AccountRepository(db));
        }


        public ICustomerRepository Customer => _customerRepo.Value;

        public IBillRepository Bill => _billrepo.Value;

        public IOrderDetailRepository OrderDetail => _orderDetailRepo.Value;

        public IProductRepository Product => _productRepo.Value;

        public IProductTypeRepository ProductType => _productTypeRepo.Value;

        public IAccountRepository Account => _accountRepo.Value;

        

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
