using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IBillService
    {
         IEnumerable<Bill> GetAll(bool trackChanges);
    }
}
