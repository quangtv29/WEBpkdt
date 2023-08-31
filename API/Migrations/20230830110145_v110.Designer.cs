﻿// <auto-generated />
using System;
using API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230830110145_v110")]
    partial class v110
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("isDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("User")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("API.Entities.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("CustomerID")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<DateTime?>("Time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("DATEADD(hour, 7, GETUTCDATE())");

                    b.Property<int?>("TotalMoney")
                        .HasColumnType("int");

                    b.Property<bool?>("isDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("API.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("1947c256-1b0d-4a2a-8f4c-6fb3221aa542"));

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool?>("isDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("API.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TotalMoney")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool?>("isDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("isSave")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Describe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Image")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ImportPrice")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Price")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Producer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("ProductTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool?>("isDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("API.Entities.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("isDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("API.Entities.Bill", b =>
                {
                    b.HasOne("API.Entities.Customer", null)
                        .WithMany("Bill")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Customer", b =>
                {
                    b.HasOne("API.Entities.Account", null)
                        .WithMany("Customer")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("API.Entities.OrderDetail", b =>
                {
                    b.HasOne("API.Entities.Bill", null)
                        .WithMany("OrderDetail")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Product", null)
                        .WithMany("OrderDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.HasOne("API.Entities.ProductType", null)
                        .WithMany("Product")
                        .HasForeignKey("ProductTypeID");
                });

            modelBuilder.Entity("API.Entities.Account", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("API.Entities.Bill", b =>
                {
                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("API.Entities.Customer", b =>
                {
                    b.Navigation("Bill");
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("API.Entities.ProductType", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
