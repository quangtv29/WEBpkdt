using API.Entities.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Bill : BaseEntity<Guid>
    {
        [ForeignKey("Customer")]
        [Required]
        public Guid?  CustomerID { get; set; }
        public DateTime? Time { get; set; }
        [Required, StringLength(255)]
        public string? Address { get; set; }
        [Required,StringLength(12)]
        public string? PhoneNumber { get; set; }
        public int? Discount { get; set; }
        public int? TotalMoney { get; set; }    
        [Required, StringLength(30)]
        public Status? Status { get; set; }
        public string? Note { get; set; }

        [NotMapped]
        public string? ConvertDiscount { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
