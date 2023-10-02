using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IBillRepository : IRepositoryBase<Bill>
    {
        Task<IEnumerable<Bill>> GetAllBill (bool trackChanges);

        Task<IEnumerable<Bill>> GetAllBillFromCustomer (Guid? customerId, bool trackChanges);

        void createBill (Bill bill);
    }
}
