using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class BillRepository : RepositoryBase<Bill>, IBillRepository
    {
        public BillRepository(DataContext db) : base(db)
        {

        }

        public  void createBill(Bill bill)
        {
            Create(bill);
        }

        public async Task<IEnumerable<Bill>> GetAllBill(bool trackChanges)
        {
            var bill = await GetAll(trackChanges).Where(b => b.isDelete == false).ToListAsync();
            return bill;
        }

        public async Task<IEnumerable<Bill>> GetAllBillFromCustomer(Guid? customerId, bool trackChanges)
        {
            var bill = await GetAllByCondition(p=>p.CustomerID == customerId, trackChanges).Where(p=>p.isDelete == false).ToListAsync();
            return bill;
        }
    }
}
