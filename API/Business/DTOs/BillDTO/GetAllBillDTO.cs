using API.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.BillDTO
{
    public class GetAllBillDTO
    {
        public Guid ? ID { get; set; }    
        public Guid? CustomerID { get; set; }
        public DateTime? Time { get; set; }
        [Required, StringLength(255)]
        public string? Address { get; set; }
        [Required, StringLength(12)]
        public string? PhoneNumber { get; set; }
        public int? Discount { get; set; }
        public int? TotalMoney { get; set; }
        [Required, StringLength(30)]
        public Status? Status { get; set; }
        public string? Note { get; set; }
    }
}
