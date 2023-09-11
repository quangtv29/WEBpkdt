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


        public ICustomerRepository _customerRepository => _customerRepo.Value;

        public IBillRepository _billRepository => _billrepo.Value;

        public IOrderDetailRepository _orderDetailRepository => _orderDetailRepo.Value;

        public IProductRepository _productRepository => _productRepo.Value;

        public IProductTypeRepository _productTypeRepository => _productTypeRepo.Value;

        public IAccountRepository _accountRepository => _accountRepo.Value;

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
