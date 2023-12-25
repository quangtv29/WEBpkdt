using Microsoft.Identity.Client;

namespace API.Business.DTOs.SaleDetailDTO
{
    public class CreateSaleDetailDTO
    {
        public Guid? SaleId { get; set; }
        public string? CustomerId { get; set; }
    }
}
