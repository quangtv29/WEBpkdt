
using API.Entities.Enum;

namespace API.Business.DTOs.CustomerDTO
{
    public class CreateCustomerDTO
    {
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }


        public bool? isActive { get; set; } = true;

        public string? Id { get; set; }

    }
}
