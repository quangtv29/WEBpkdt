namespace API.Business.DTOs.BillDTO
{
    public class GetInfoOrderDTO
    {
        public int? Quantity { get; set; }
        
        public double? TotalOrder { get; set; }
        public double? TotalOrderofMonth { get; set; }

        public double? TotalDiscount { get; set; }
        public int? QuantityCancel { get; set; }
    }
}
