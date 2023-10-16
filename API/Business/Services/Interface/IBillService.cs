﻿using API.Business.DTOs.BillDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IBillService
    {
         Task<IEnumerable<Bill>> GetAll(bool trackChanges);
        Task<IEnumerable<Bill>> GetAllBillFromCustomer(string? customerId, bool trackChanges);

        Task<bool> createBill(CreateBillDTO bill, string code);

       

    }
}
