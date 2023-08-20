using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Customer : BaseEntity<Guid>
    {
        [ForeignKey("Account")]
        public Guid ?AccountId { get; set; }
        [StringLength (12)]
        public string ?PhoneNumber { get; set; }
        [StringLength (255)]
        public string ?Address { get; set; }
        [StringLength(255)]
        public string ?Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Bill> Bill { get; set; }
    }
}
