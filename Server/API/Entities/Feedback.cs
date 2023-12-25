using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Feedback : BaseEntity<Guid>
    {
        public int? Star { get; set; }

        public string? Comment { get; set; }
         
        public string? UserName { get; set; }
        public Guid? ProductId { get; set; }
        public Product Product { get; set; }
        
        public bool? isShow { get; set; }

        public string? Image { get; set; }

        [NotMapped]
        public string? Convert { get; set; }
        [NotMapped]

        public string? FixName { get; set; }

        [NotMapped]
        public string? Avatar { get; set; }

    }
}
