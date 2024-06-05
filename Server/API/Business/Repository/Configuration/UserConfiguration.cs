using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Business.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            string hashedPassword = passwordHasher.HashPassword(null, "quang123"); 

            builder.HasData(
                new User()
                {
                    Id = "57d08f9f-053a-47e4-8429-bb0d27c90b65",
                   UserName = "admin",
                   NormalizedUserName= "ADMIN",
                   PasswordHash = hashedPassword,
                   FirstName = "Vinh",
                   LastName = "Quang",
                   isDelete = false                
                },
                new User()
                {
                    Id = "57d08f9f-053a-47e4-8429-bb0d27c90b66",
                    UserName = "linh1",
                    NormalizedUserName = "LINH1",
                    PasswordHash = hashedPassword,
                    FirstName = "Phương",
                    LastName = "Linh",
                    isDelete = false
                }
           
                );
        }
    }
}
