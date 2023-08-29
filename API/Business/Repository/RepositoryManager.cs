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
        public RepositoryManager(DataContext db )
        {
            _db = db;
            _customerRepo = new Lazy<ICustomerRepository>(() => new CustomerRepository(db));
            _billrepo = new Lazy<IBillRepository>(() => new BillRepository(db));
            _orderDetailRepo = new Lazy<IOrderDetailRepository>(() => new OrderDetailRepository(db));
            _productRepo = new Lazy<IProductRepository>(() => new ProductRepository(db));
        }


        public ICustomerRepository _customerRepository => _customerRepo.Value;

        public IBillRepository _billRepository => _billrepo.Value;

        public IOrderDetailRepository _orderDetailRepository => _orderDetailRepo.Value;

        public IProductRepository _productRepository => _productRepo.Value;

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
