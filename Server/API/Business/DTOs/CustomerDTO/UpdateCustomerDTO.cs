using API.Entities.Enum;

namespace API.Business.DTOs.CustomerDTO
{
    public class UpdateCustomerDTO
    {
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public Gender Gender { get; set; }
    }
}
