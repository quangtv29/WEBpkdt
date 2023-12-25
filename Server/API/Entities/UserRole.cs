using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class UserRole
    {
        [ForeignKey("User")]
        public string? UserId { get; set; }
        [ForeignKey("Role")]
        public string? RoleId { get; set; }
    }
}
