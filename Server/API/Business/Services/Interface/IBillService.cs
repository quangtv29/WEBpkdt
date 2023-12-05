using API.Business.DTOs.BillDTO;
using API.Business.Shared;
using API.Entities;
using API.Entities.Enum;

namespace API.Business.Services.Interface
{
    public interface IBillService
    {
         Task<IEnumerable<Bill>> GetAll(bool trackChanges, Status status, BillParameters billParameters);
        Task<IEnumerable<Bill>> GetAllBillFromCustomer(string? customerId, bool trackChanges, Status status);

        Task<Bill> createBill(CreateBillDTO bill, string code);

        Task<GetAllBillDTO> getBillById(Guid? Id);

        Task<Bill> updateBillById(UpdateBillDTO bill);

        Task<GetInfoOrderDTO> getInfoOrder(string? Id);

        Task<Bill> updateStatusBill(Guid? Id, Status status);

        Task<List<double?>> TotalRevenueLast12Months();

    }
}
