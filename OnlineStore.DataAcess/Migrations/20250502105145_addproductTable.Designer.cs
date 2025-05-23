﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.DataAcess.Data;

#nullable disable

namespace OnlineStore.DataAcess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250502105145_addproductTable")]
    partial class addproductTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Airopods",
                            DisplayOrder = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Mobile Phones",
                            DisplayOrder = 2
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Watches",
                            DisplayOrder = 3
                        });
                });

            modelBuilder.Entity("OnlineStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Brand = "Samsung",
                            Description = "Samsung Galaxy S21 with 8GB RAM and 128GB Storage.",
                            Price = 699.99m,
                            Title = "Samsung Galaxy S21"
                        },
                        new
                        {
                            ProductId = 2,
                            Brand = "Apple",
                            Description = "iPhone 13 with A15 Bionic chip and 128GB Storage.",
                            Price = 799.00m,
                            Title = "Apple iPhone 13"
                        },
                        new
                        {
                            ProductId = 3,
                            Brand = "Sony",
                            Description = "Noise-canceling wireless headphones with 30 hours battery life.",
                            Price = 348.00m,
                            Title = "Sony WH-1000XM4 Headphones"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
