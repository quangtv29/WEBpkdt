using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Blog : BaseEntity<Guid>
    {
        public string? Title { get; set; }

        public string? Image { get; set; }

        public string? Content { get;set; }
        public DateTime Create { get; set; }

        [NotMapped] 
       public string? FormatDate { get; set; }
        [NotMapped]
        public string? LastChange { get; set; }
    }
}
