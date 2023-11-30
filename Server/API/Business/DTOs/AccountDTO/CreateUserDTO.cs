using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.AccountDTO
{
    public class CreateUserDTO
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }

        public DateTime CreateAccount = DateTime.Now;
        public ICollection<string>? Roles = new List<string> { "Customer" };
    }
}
