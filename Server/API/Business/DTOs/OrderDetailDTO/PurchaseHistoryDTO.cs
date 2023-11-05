using API.Entities.Enum;
using Microsoft.Identity.Client;

namespace API.Business.DTOs.OrderDetailDTO
{
    public class PurchaseHistoryDTO
    {
        public Guid? Id { get; set; }

        public DateTime? Time { get; set; }

        public Guid? ProductId { get; set; }

        public string? Product { get; set; }

        public int? Quantity { get; set; }

       
        public int? Price { get; set; }

        public int? TotalMoney { get; set; }

        public string? Image { get; set; }

    }
}
