using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class ProductType : BaseEntity <Guid>
    {
        [Required,StringLength(50)]
        public string? Name { get; set; }

        [ForeignKey("ProductList")]
        public Guid? ProductListId { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
