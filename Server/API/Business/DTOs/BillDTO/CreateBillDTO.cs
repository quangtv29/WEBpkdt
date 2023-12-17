using API.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.Business.DTOs.BillDTO
{
    public class CreateBillDTO
    {
        public string? CustomerId { get; set; }
        public string? Address { get; set; } 
        public string? PhoneNumber { get; set; }
        public int? TotalMoney { get; set; }
        public string? Note { get; set; }
        public string? Name { get; set; }

        public Status status = Status.Cart;
    }
}
