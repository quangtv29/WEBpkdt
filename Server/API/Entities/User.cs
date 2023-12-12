using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class User :  IdentityUser
    {
        public bool? isDelete { get; set; }
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       public Customer Customer { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime CreateAccount { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public DateTime LimitReset { get; set; }

       
    }
}
