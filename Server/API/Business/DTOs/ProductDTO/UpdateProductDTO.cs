using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.ProductDTO.cs
{
    public class UpdateProductDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        
        public int? Quantity { get; set; }
        
        public int? ImportPrice { get; set; }
       
        public int? Price { get; set; }

        public Guid? ProductTypeID { get; set; }

        public string? Producer { get; set; }

        public string? Describe { get; set; }

        public IFormFile? Image { get; set; }

        public DateTime? LastModificationTime = DateTime.Now;
    }
}
