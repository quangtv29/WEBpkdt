namespace API.Entities
{
    public class Photo: BaseEntity
    {
        public string? Image { get; set; }
        public Guid? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
