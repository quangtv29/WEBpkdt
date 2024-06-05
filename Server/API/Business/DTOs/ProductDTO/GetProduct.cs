namespace API.Business.DTOs.ProductDTO
{
    public class GetProduct
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }

        public int? Quantity { get; set; }

        public int? ImportPrice { get; set; }
        public int? Sold { get; set; }

        public int? Price { get; set; }

        public Guid? ProductTypeID { get; set; }

        public string? Producer { get; set; }

        public string? Describe { get; set; }

        public List<string>? Image { get; set; }

        public Double? StarRating { get; set; }

        public string? ProductTypeName { get; set; }


    }
}
