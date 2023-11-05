
namespace API.Business.DTOs.OrderDetailDTO
{
    public class CreateCartDTO
    {
        public Guid? BillId { get; set; }
        public int? Price { get; set; }

        public Guid? ProductId { get; set; }

        public int? Quantity { get; set; }

        public int? TotalMoney { get; set; }

        public DateTime? LastModificationTime = DateTime.Now;

        public bool? isSave = true;
    }
}
