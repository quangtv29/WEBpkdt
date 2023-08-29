using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class DataContext : DbContext
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

            builder.Entity<Account>(e => {
                e.HasKey(ac => ac.Id);
            });

            builder.Entity<Bill>(e =>
            {
                e.Property(e => e.Time).HasDefaultValueSql("DATEADD(hour, 7, GETUTCDATE())");
            });
            builder.Entity<Customer>(e =>
            {
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
                e.Property(e => e.isDelete).HasDefaultValue(false);
            });
        }


    }
}
