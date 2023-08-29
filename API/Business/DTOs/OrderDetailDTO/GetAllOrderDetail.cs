using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.OrderDetailDTO
{
    public class GetAllOrderDetail
    {
        public Guid? Id { get; set; }
        public Guid? BillId { get; set; }
       
        public Guid? ProductId { get; set; }
       
        public int? Quantity { get; set; }
      
        public int? TotalMoney { get; set; }

        public string? Name { get; set; }   
    }
}
