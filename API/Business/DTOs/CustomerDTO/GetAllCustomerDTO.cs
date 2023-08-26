using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.CustomerDTO
{
    public class GetAllCustomerDTO
    {
        public Guid? Id { get; set; }
        public Guid? AccountId { get; set; }
        
        public string? PhoneNumber { get; set; }
       
        public string? Address { get; set; }
       
        public string? Name { get; set; }
        public string DateOfBirth { get; set; }
    }
}
