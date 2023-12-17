using API.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Bill : BaseEntity<Guid>
    {
        [ForeignKey("Customer")]
        [Required]
        public string?  CustomerID { get; set; }
        public DateTime Time { get; set; }
        [Required, StringLength(255)]
        public string? Address { get; set; }
        [Required,StringLength(12)]
        public string? PhoneNumber { get; set; }
        public double? Discount { get; set; }
        public int? TotalMoney { get; set; }    
        [Required, StringLength(30)]
        public Status? Status { get; set; }
        public string? Note { get; set; }

        public string? DiscountCode { get; set; }
        public double? IntoMoney { get; set; } 

        public string? Name { get; set; }

        [NotMapped]
        public string? ConvertDiscount { get; set; }
        [NotMapped]
        public string? ConvertTotalMoney { get; set; }

        [NotMapped]
        public string? FormatDate { get; set; }
        public ICollection<OrderDetail>? OrderDetail { get; set; }

    }
}
