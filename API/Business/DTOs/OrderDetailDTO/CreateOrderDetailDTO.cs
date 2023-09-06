using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.OrderDetailDTO
{
    public class CreateOrderDetailDTO
    {
       
        public Guid? BillId { get; set; }

        public int? Price = 0;
        
        public Guid? ProductId { get; set; }
        
        public int? Quantity { get; set; }
       
        public int? TotalMoney { get; set; }

        public DateTime? LastModificationTime = DateTime.Now;

        public bool? isSave = true;
    }
}
