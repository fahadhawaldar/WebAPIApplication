using Microsoft.EntityFrameworkCore;
using WebAPIApp.Models;
namespace WebAPIApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
            //modelBuilder.Entity<Product>()
            //    .Property(p=>p.Description)
            //    .HasPrecision(18, 2);
            //modelBuilder.Entity<Product>()
            //    .Property(p => p.Id);

            // Seed some initial data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Price = 19.99m, Description = "First product" },
                new Product { Id = 2, Name = "Product 2", Price = 29.99m, Description = "Second product" }
            );
        }
    }

}
