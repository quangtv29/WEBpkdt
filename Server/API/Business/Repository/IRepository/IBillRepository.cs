using API.Entities;
using API.Entities.Enum;

namespace API.Business.Repository.IRepository
{
    public interface IBillRepository : IRepositoryBase<Bill>
    {
        Task<IEnumerable<Bill>> GetAllBill (bool trackChanges);

        Task<Bill> getBillById(Guid? ID);
        Task<IEnumerable<Bill>> GetAllBillFromCustomer (string? customerId, bool trackChanges, Status status);
        Task<IEnumerable<Bill>> GetAllBillFromCustomerr(string? customerId, bool trackChanges);
        void createBill (Bill bill);

        Task<Bill> updateBillById(Guid? Id);
    }
}
