using Microsoft.Identity.Client;

namespace API.Entities
{
    public class Sale :  BaseEntity
    {
        public string? DiscountCode { get; set; }
        public int? Money { get; set; }
        public int? Quantity { get; set; }
        public int? Count { get; set; } = 0;
        public double? Percent { get; set; }
        
        public int? MinBill { get; set; }
        public DateTime? EndDate { get; set; }
      
    }
}
