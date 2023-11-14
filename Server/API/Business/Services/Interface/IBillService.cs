using API.Business.DTOs.BillDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IBillService
    {
         Task<IEnumerable<Bill>> GetAll(bool trackChanges);
        Task<IEnumerable<Bill>> GetAllBillFromCustomer(string? customerId, bool trackChanges);

        Task<Bill> createBill(CreateBillDTO bill, string code);

        Task<GetAllBillDTO> getBillById(Guid? Id);

        Task<Bill> updateBillById(UpdateBillDTO bill);

    }
}
