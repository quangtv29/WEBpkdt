using System.ComponentModel.DataAnnotations;

namespace API.Business.DTOs.AccountDTO
{
    public class LoginValidateDTO
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Password name is required")]
        public string? Password
        {
            get; init;
        }
    }
}
