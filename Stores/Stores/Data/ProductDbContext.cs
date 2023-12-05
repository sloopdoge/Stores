using Microsoft.EntityFrameworkCore;
using Stores.Entities;

namespace Stores.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany()
               .HasForeignKey(p => p.CategoryID)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
               .HasOne(p => p.SubCategory)
               .WithMany()
               .HasForeignKey(p => p.SubCategoryID)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
