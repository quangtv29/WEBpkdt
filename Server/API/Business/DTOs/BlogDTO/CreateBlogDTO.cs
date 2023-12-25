namespace API.Business.DTOs.BlogDTO
{
    public class CreateBlogDTO
    {
        public string? Title { get; set; }

        public IFormFile? Image { get; set; }

        public string? Content { get; set; }

        public DateTime Create  = DateTime.Now;
    }
}
