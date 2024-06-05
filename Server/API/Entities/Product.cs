using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Product : BaseEntity<Guid>

    {
        [Required,StringLength(255)]
        public string? Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public int? ImportPrice { get; set; }
        [Required]
        public int? Price { get; set; }

        [ForeignKey("ProductType")]
        public Guid? ProductTypeID { get; set; }
        [StringLength(50)]
        public string? Producer { get; set; }

        public string? Describe { get; set; }

        public string? Image { get; set; }

        [NotMapped]
        public string? formatPrice{ get; set; }
        [NotMapped]
        public string? formatImportPrice { get; set; }
      
        public int? Sold { get; set; } = 0;

        public ICollection<Feedback> Feedback { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }

        public ICollection<Photo> Photo { get; set; }
      

    }
}
