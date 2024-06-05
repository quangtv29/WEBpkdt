namespace API.Business.DTOs.PhotoDTO
{
    public class CreatePhotoDTO
    {
        public IFormFile? Image { get; set; }
        public Guid? ProductId { get; set; }
    }
}
