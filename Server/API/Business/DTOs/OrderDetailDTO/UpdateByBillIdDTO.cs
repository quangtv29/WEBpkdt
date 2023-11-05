namespace API.Business.DTOs.OrderDetailDTO
{
    public class UpdateByBillIdDTO
    {
        public Guid? orderDetailId { get; set; }
      public Guid? BillId { get; set; }
    }
}
