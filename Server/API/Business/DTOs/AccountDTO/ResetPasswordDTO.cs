namespace API.Business.DTOs.AccountDTO
{
    public class ResetPasswordDTO
    {
        public string? Id { get; set; }
        public string? Password { get; set; }

        public string? NewPassword { get; set; }
    }
}
