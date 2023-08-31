namespace API.Business.DTOs.OrderDetailDTO
{
    public class UpdateTotalMoneyDTO
    {
        public Guid? BillId { get; set; }
        public Guid? ProductId { get; set; }
        
        public int? Quantity { get; set; }
        public bool isSave = false;
        public int? TotalMoney { get; set; }

        public DateTime? LastModificationTime = DateTime.Now;
    }
}
