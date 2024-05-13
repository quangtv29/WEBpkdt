﻿using Microsoft.AspNetCore.Identity;
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
                    UserId = "57d08f9f-053a-47e4-8429-bb0d27c90b65",
                    RoleId = "57d08f9f-053a-47e4-8429-bb0d27c90b78"
                }
                ) ;
        }
    }
}
