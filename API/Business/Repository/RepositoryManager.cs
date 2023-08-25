using API.Business.Repository.IRepository;
using API.Database;

namespace API.Business.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _db;
        private readonly Lazy<ICustomerRepository> _customerRepo;
        private readonly Lazy<IBillRepository> _billrepo; 
        public RepositoryManager(DataContext db )
        {
            _db = db;
            _customerRepo = new Lazy<ICustomerRepository>(() => new CustomerRepository(db));
            _billrepo = new Lazy<IBillRepository>(() => new BillRepository(db));
        }


        public ICustomerRepository _customerRepository => _customerRepo.Value;

        public IBillRepository _billRepository => _billrepo.Value;


        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
