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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Airopods", DisplayOrder = 1 },
                new Category { Id = 2, CategoryName = "Mobile Phones", DisplayOrder = 2 },
                new Category { Id = 3, CategoryName = "Watches", DisplayOrder = 3 }
                );
        }
    }
}
