using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IBillRepository : IRepositoryBase<Bill>
    {
        Task<IEnumerable<Bill>> GetAllBill (bool trackChanges);

        Task<Bill> getBillById(Guid? ID);
        Task<IEnumerable<Bill>> GetAllBillFromCustomer (string? customerId, bool trackChanges);

        void createBill (Bill bill);
    }
}
