using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class SaleDetail : BaseEntity<Guid>
    {
        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Sale")]
        public Guid? SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
