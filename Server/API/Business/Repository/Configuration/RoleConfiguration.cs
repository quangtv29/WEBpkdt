using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Business.Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(

                new IdentityRole
                {
                    Id = "57d08f9f-053a-47e4-8429-bb0d27c90b78",
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = "f8d0154b-4841-49d3-8b2c-b5038469c018",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole
                {
                    Id = "0da27ab0-4abe-4ad3-9800-3ee045177554",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
                );
        }
    }
}
