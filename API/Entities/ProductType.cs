using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class ProductType : BaseEntity <Guid>
    {
        [Required,StringLength(50)]
        public string? Name { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
