using API.Business.DTOs.BillDTO;
using API.Business.Repository.IRepository;
using API.Business.Shared;
using API.Database;
using API.Entities;
using API.Entities.Enum;
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

        public async Task<IEnumerable<Bill>> GetAllBill(bool trackChanges, Status status, BillParameters billParameters)
        {
            if (status == 0)
            {
                var bills = await GetAll(trackChanges).Where(b => b.isDelete == false && b.Status == status)
               .OrderByDescending(p => p.ShippingDate)
               .Skip((billParameters.PageNumber - 1) * billParameters.PageSize)
               .Take(billParameters.PageSize)
               .ToListAsync();
                return bills;
            }
            else
            {
                var bill = await GetAll(trackChanges).Where(b => b.isDelete == false && b.Status == status)
                    .OrderByDescending(p => p.Time)
                    .Skip((billParameters.PageNumber - 1) * billParameters.PageSize)
                    .Take(billParameters.PageSize)
                    .ToListAsync();
                return bill;
            }
        }

        public async Task<IEnumerable<Bill>> GetAllBillFromCustomer(string? customerId, bool trackChanges, Status status)
        {
            if (status == 0)
            {
                var bill = await GetAllByCondition(p => p.CustomerID == customerId, trackChanges)
               .Where(p => p.isDelete == false && p.Status == status)
               .OrderByDescending(p => p.ShippingDate)
               .ToListAsync();
                return bill;
            }
            else
            {
                var bill = await GetAllByCondition(p => p.CustomerID == customerId, trackChanges)
                    .Where(p => p.isDelete == false && p.Status == status)
                    .OrderByDescending(p => p.Time)
                    .ToListAsync();
                return bill;
            }
        }

        public async Task<IEnumerable<Bill>> GetAllBillFromCustomerr(string? customerId, bool trackChanges)
        {
            var bill = await GetAllByCondition(p => p.CustomerID == customerId, trackChanges).Where(p => p.isDelete == false ).ToListAsync();
            return bill;
        }

        public async Task<Bill> getBillById(Guid? ID, bool trackChanges)
        {
            var bill = await GetAllByCondition(p => p.Id == ID, trackChanges)
                .Where(p => p.isDelete == false)
                .FirstOrDefaultAsync();
             return bill;
        }

        public async Task<List<Revenue>> TotalRevenueLast12Months()
        {
            DateTime currentDate = DateTime.Now;

            List<Revenue> revenues = new List<Revenue>();
            for (int i = 1; i <= 12; i++)
            {
                DateTime month = currentDate.AddMonths(-i);

                double? bill = await GetAll(false)
                    .Where(p => p.Status == 0 && p.isDelete == false && p.Time.Month == month.Month && p.Time.Year == month.Year)
                    .SumAsync(p => p.IntoMoney);

                revenues.Add(new Revenue
                {
                    Revenues = bill,
                    Datetime = $"{month.Month}/{month.Year}"
                });
            }

            return revenues;
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
