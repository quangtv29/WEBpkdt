﻿using API.Business.Repository.Configuration;
using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ProductType> ProductType {get;set;}
        public DbSet <Bill> Bill { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<ProductList> ProductList { get; set; }
       
        public DbSet<Feedback> Feedback { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());

           

           

          
                

            builder.Entity<Bill>(e =>
            {
                e.Property(e => e.Time).HasDefaultValueSql("DATEADD(hour, 7, GETUTCDATE())");
                e.Property(e => e.LastModificationTime).HasDefaultValueSql("GETDATE()");
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
                e.Property(e => e.isDelete).HasDefaultValue(false);

            });
            builder.Entity<Customer>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValueSql("GETDATE()");
                e.Property(e => e.isDelete).HasDefaultValue(false);
            });
            builder.Entity<Product>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValueSql("GETDATE()");
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
                e.Property(e => e.isDelete).HasDefaultValue(false);

            });
            builder.Entity<ProductType>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValueSql("GETDATE()");
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
            });
            builder.Entity<Sale>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValueSql("GETDATE()");
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
                e.Property(e => e.Quantity).HasDefaultValue(0);
                e.Property(e => e.Percent).HasDefaultValue(1.0);
            });
            builder.Entity<ProductList>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValueSql("GETDATE()");
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
            });
            builder.Entity<Feedback>(e =>
            {
                e.Property(e => e.LastModificationTime).HasDefaultValueSql("GETDATE()");
                e.Property(e => e.Id).HasDefaultValue(Guid.NewGuid());
            });
            builder.Entity<User>()
            .HasOne(e => e.Customer)
            .WithOne(e => e.User)
            .HasForeignKey<Customer>(e => e.Id);

        }


    }
}
