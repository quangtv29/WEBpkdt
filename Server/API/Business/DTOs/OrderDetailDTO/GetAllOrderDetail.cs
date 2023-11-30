using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace API.Business.DTOs.OrderDetailDTO
{
    public class GetAllOrderDetail
    {
        public Guid? Id { get; set; }
        public Guid? BillId { get; set; }
       
        public Guid? ProductId { get; set; }

        public int? Price { get; set; }
       
        public int? Quantity { get; set; }
      
        public int? TotalMoney { get; set; }  

        public string? Name { get; set; }
        public string? Image { get; set; }

    }
}
