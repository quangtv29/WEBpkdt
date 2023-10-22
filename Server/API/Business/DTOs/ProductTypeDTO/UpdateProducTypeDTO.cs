namespace API.Business.DTOs.ProductTypeDTO
{
    public class UpdateProducTypeDTO
    {
        public string? Name { get; set; }
        public bool? isDelete = false;
        public DateTime? LastModificationTime = DateTime.Now;
    }
}
