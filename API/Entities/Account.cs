using API.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Account : BaseEntity<Guid>
    {
        [Required, StringLength(255)]
        public string? User { get; set; }
        [Required, StringLength(255)]
        public string? Password { get; set; }
        [Required]
        public Position Position { get; set; }

        public ICollection<Customer>? Customer { get; set; }

    }
}
