namespace API.Business.DTOs.SaleDTO
{
    public class CreateDiscountCode
    {
        public string? DiscountCode { get; set; }
        public int? Money { get; set; }
        public int? Quantity { get; set; }
        public double? Percent { get; set; }
        public int? MinBill { get; set; }
        public DateTime EndDate { get; set; }
    }
}
