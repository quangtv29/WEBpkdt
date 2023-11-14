using API.Entities.Enum;

namespace API.Business.DTOs.BillDTO
{
    public class UpdateBillDTO
    {
        public Guid? Id { get; set; }
        public double? Discount { get; set; }
        public double? IntoMoney { get; set; }

        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public Status status = Status.Ordered;
    }
}
