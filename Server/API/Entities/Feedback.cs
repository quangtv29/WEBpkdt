namespace API.Entities
{
    public class Feedback : BaseEntity<Guid>
    {
        public int? Star { get; set; }

        public string? Comment { get; set; }
         
        public string? UserName { get; set; }
        public Guid? ProductId { get; set; }
        public Product Product { get; set; }

    }
}
