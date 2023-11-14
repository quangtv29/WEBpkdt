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

        public async Task<IEnumerable<Bill>> GetAllBillFromCustomer(string? customerId, bool trackChanges)
        {
            var bill = await GetAllByCondition(p=>p.CustomerID == customerId, trackChanges).Where(p=>p.isDelete == false).ToListAsync();
            return bill;
        }

        public async Task<Bill> getBillById(Guid? ID)
        {
            var bill = await GetAllByCondition(p => p.Id == ID, true)
                .Where(p => p.isDelete == false)
                .FirstOrDefaultAsync();
             return bill;
        }

        public async Task<Bill> updateBillById(Guid? Id)
        {
            var bill = await GetAllByCondition(p => p.Id == Id, true)
                .Where(p => p.isDelete == false)
                .FirstOrDefaultAsync();
            return bill;
        }
    }
}
