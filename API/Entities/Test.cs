using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
