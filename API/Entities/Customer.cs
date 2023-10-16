using API.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Customer 
    {
        
        public string? Id { get; set; }
        [StringLength (255)]
        public string ?Address1 { get; set; }
        public string? Address2 { get; set; }
       
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public  DateTime? LastModificationTime { get; set; }
        public bool? isDelete { get; set; }
        public bool? isActive { get; set; }
        [NotMapped]
        public string? FormatDate { get; set; }


        public ICollection<Bill>? Bill { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
