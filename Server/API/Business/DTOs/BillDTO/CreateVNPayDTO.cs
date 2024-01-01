namespace API.Business.DTOs.BillDTO
{
    public class CreateVNPayDTO
    {
        public Guid? Id { get; set; }
        public double? Amount { get; set; }
        public string? CallBackUrl { get; set; }
    }
}
