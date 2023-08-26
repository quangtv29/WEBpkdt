using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IBillService
    {
         Task<IEnumerable<Bill>> GetAll(bool trackChanges);
        Task<IEnumerable<Bill>> GetAllBillFromCustomer(Guid? customerId, bool trackChanges);
    }
}
