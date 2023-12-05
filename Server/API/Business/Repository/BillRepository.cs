﻿using API.Business.Repository.IRepository;
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
            var bill = await GetAll(trackChanges).Where(b => b.isDelete == false && b.Status == status)
                .OrderByDescending(p=>p.Time)
                .Skip((billParameters.PageNumber - 1)*billParameters.PageSize)
                .Take(billParameters.PageSize)
                .ToListAsync();
            return bill;
        }

        public async Task<IEnumerable<Bill>> GetAllBillFromCustomer(string? customerId, bool trackChanges, Status status)
        {
            var bill = await GetAllByCondition(p => p.CustomerID == customerId, trackChanges)
                .Where(p => p.isDelete == false && p.Status == status)
                .OrderByDescending(p => p.Time)
                .ToListAsync();
            return bill;
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

        public async Task<List<double?>> TotalRevenueLast12Months()
        {
            DateTime currentDate = DateTime.Now;
            List<double?> revenueList = new List<double?>();

            for (int i = 1; i <= 12; i++)
            {
                DateTime month = currentDate.AddMonths(-i);
                double? bill = await GetAll(false)
                    .Where(p => p.Status == 0 && p.isDelete == false && p.Time.Month == month.Month && p.Time.Year == month.Year)
                    .SumAsync(p => p.IntoMoney);

                revenueList.Add(bill);
            }

            return revenueList;
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
