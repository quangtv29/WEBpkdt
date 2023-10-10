using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.ProductDTO.cs
{
    public class GetAllProductDTO
    {
        public  Guid? Id { get; set; }
        public string? Name { get; set; }
       
        public int? Quantity { get; set; }
       
        public string? ImportPrice { get; set; }
       
        public string? Price { get; set; }

        public Guid? ProductTypeID { get; set; }
       
        public string? Producer { get; set; }

        public string? Describe { get; set; }

        public Decimal? Image { get; set; }

      
    }
}
