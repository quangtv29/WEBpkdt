using API.Business.Repository.IRepository;
using API.Database;

namespace API.Business.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _db;
        private readonly Lazy<ICustomerRepository> _customerRepo;
        public RepositoryManager(DataContext db )
        {
            _db = db;
            _customerRepo = new Lazy<ICustomerRepository>(() => new CustomerRepository(db));
        }


        public ICustomerRepository _customerRepository => _customerRepo.Value;

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
