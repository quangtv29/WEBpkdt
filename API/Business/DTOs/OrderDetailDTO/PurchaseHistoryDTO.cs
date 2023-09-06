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

        public string? Quantity { get; set; }

        public string? TotalMoney { get; set; }

        public Decimal? Image { get; set; }

    }
}
