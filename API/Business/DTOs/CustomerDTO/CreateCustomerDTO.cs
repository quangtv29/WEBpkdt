using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.CustomerDTO
{
    public class CreateCustomerDTO
    {
        public Guid? AccountId { get; set; }
       
        public string? PhoneNumber { get; set; }
       
        public string? Address { get; set; }
       
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
