using API.Business.Repository.Configuration;
using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace API.Database
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ProductType> ProductType {get;set;}
        public DbSet<Account> Account { get; set; }
        public DbSet <Bill> Bill { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
       


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());


            builder.Entity<Account>(e => {
                e.Property(e => e.LastModificationTime).HasDefaultValue(DateTime.Now);
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
                e.HasKey(ac => ac.Id);
                e.HasIndex(ac => ac.User).IsUnique();
                e.Property(e => e.isDelete).HasDefaultValue(false);

            });

            builder.Entity<Bill>(e =>
            {
                e.Property(e => e.Time).HasDefaultValueSql("DATEADD(hour, 7, GETUTCDATE())");
                e.Property(e => e.LastModificationTime).HasDefaultValue(DateTime.Now);
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
                e.Property(e => e.isDelete).HasDefaultValue(false);

            });
            builder.Entity<Customer>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValue(DateTime.Now);
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
                e.Property(e => e.isDelete).HasDefaultValue(false);
            });
            builder.Entity<Product>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValue(DateTime.Now);
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
                e.Property(e => e.isDelete).HasDefaultValue(false);

            });
            builder.Entity<ProductType>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValue(DateTime.Now);
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
            });
        }


    }
}
