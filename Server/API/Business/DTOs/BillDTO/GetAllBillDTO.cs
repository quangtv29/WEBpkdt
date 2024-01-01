using API.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.BillDTO
{
    public class GetAllBillDTO
    {
        public Guid? ID { get; set; }    
        public string? CustomerID { get; set; }
        public DateTime Time { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int? TotalMoney { get; set; }
        public Status? Status { get; set; }
        public string? Note { get; set; }
        public string? Name { get; set; }

        public double? Discount { get; set; }
        public double? IntoMoney { get; set; }
 
        public string? FormatDate { get; set; }
        public string? FormatShippingDate { get; set; }

        public DateTime ShippingDate { get; set; }
        public string? DiscountCode { get; set; }
        public string? UserName { get; set; }

    }
}
