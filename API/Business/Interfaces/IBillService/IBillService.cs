using API.Business.DTOs.BillDTO;

namespace API.Business.Interfaces.IBillService
{
    public interface IBillService
    {
        Task<List<GetAllBillDTO>> GetAll();
    }
}
