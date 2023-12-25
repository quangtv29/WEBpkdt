using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Business.Repository.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
           

            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId ="db2ef474-d30b-490f-a98c-15a3347b2ab9",
                    RoleId = "a5bc451a-281d-4bcd-bde5-cac2d09df773"
                }
                ) ;
        }
    }
}
