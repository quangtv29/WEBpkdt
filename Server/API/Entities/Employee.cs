using API.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Employee : BaseEntity<Guid>
    {
        public string? PhoneNumber { get; set; }
        [StringLength(255)]
        public string? Address { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender? Gender { get; set; }

        public bool? isActive { get; set; }
        public DateTime? JoinDate { get; set; } 

        //Relationship
        public string? UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Bill> Bill { get; set; }
    }
}
