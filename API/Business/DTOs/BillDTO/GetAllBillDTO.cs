using API.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.BillDTO
{
    public class GetAllBillDTO
    {
        public Guid ? ID { get; set; }    
        public Guid? CustomerID { get; set; }
        public DateTime? Time { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TotalMoney { get; set; }
        public Status? Status { get; set; }
        public string? Note { get; set; }
        public string? Discount { get; set; }
    }
}
