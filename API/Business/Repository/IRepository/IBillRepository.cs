using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IBillRepository
    {
        IEnumerable<Bill> GetAllBill (bool trackChanges);
    }
}
