using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.ProductDTO.cs
{
    public class CreateProductDTO
    {
        public string? Name { get; set; }

        public int? Quatity { get; set; }
        public int? ImportPrice { get; set; }
        public int? Price { get; set; }
        public Guid? ProductTypeID { get; set; }
        public string? Producer { get; set; }

        public string? Describe { get; set; }
        public Decimal? Image { get; set; }
    }
}
