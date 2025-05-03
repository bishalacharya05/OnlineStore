using OnlineStore.Models;
using Microsoft.EntityFrameworkCore;
namespace OnlineStore.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Airopods", DisplayOrder = 1 },
                new Category { Id = 2, CategoryName = "Mobile Phones", DisplayOrder = 2 },
                new Category { Id = 3, CategoryName = "Watches", DisplayOrder = 3 }
               );
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     ProductId = 1,
                     Title = "Samsung Galaxy S21",
                     Brand = "Samsung",
                     Description = "Samsung Galaxy S21 with 8GB RAM and 128GB Storage.",
                     Price = 699.99m,
                     CategoryId = 2,
                     ImageUrl=""
                 },
                 new Product
                 {
                     ProductId = 2,
                     Title = "Apple iPhone 13",
                     Brand = "Apple",
                     Description = "iPhone 13 with A15 Bionic chip and 128GB Storage.",
                     Price = 799.00m,
                     CategoryId=2,
                     ImageUrl = ""

                 },
                 new Product
                 {
                     ProductId = 3,
                     Title = "Sony WH-1000XM4 Headphones",
                     Brand = "Sony",
                     Description = "Noise-canceling wireless headphones with 30 hours battery life.",
                     Price = 348.00m,
                     CategoryId=1,
                     ImageUrl = ""
                 }
               );
        }
    }
}
