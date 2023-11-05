namespace API.Business.DTOs.FeedbackDTO
{
    public class GetFeedbackByProductDTO
    {
        public Guid? Id { get; set; }
        public int? Star { get; set; }

        public string? Comment { get; set; }

        public string? UserName { get; set; }
        public Guid? ProductId { get; set; }
    }
}
