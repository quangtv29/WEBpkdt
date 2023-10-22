using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class ProductList : BaseEntity<Guid>
    {
        [Required]
        public string? Name { get; set; }

        public ICollection<ProductType> ProductType { get; set; }
    }
}
