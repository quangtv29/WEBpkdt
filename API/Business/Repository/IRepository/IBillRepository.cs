using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetAllBill (bool trackChanges);
    }
}
