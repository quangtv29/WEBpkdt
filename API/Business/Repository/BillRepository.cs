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

     public async Task<IEnumerable<Bill>> GetAllBill(bool trackChanges)
        {
            var bill = await GetAll(trackChanges).Where(b => b.isDelete == false).ToListAsync();
            return bill;
        }
    }
}
