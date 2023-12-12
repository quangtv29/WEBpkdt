using API.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Notification : BaseEntity<Guid>
    {
        public string? Content { get; set; }
        public DateTime Create { get; set; }
        public Watched Watched { get; set; }
        public string? Header { get; set; }
        //relationship


        [ForeignKey("Customer")]
        public string? CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
