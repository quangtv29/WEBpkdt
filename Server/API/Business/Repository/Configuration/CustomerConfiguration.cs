using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Business.Repository.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = "57d08f9f-053a-47e4-8429-bb0d27c90b65",
                    isActive = true,
                    isDelete = false,
                    LastModificationTime = DateTime.Now
                },
                new Customer
                {
                    Id= "57d08f9f-053a-47e4-8429-bb0d27c90b66",
                    isActive = true,
                    isDelete = false,
                    LastModificationTime = DateTime.Now
                } 
                );
        }
    }
}
