using Microsoft.EntityFrameworkCore;
using Stores.Entities;

namespace Stores.Data
{
    public class SubCategoryDbContext : DbContext
    {
        public SubCategoryDbContext(DbContextOptions<SubCategoryDbContext> options) : base(options)
        {

        }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategory>()
               .HasOne(sc => sc.Category)
               .WithMany(c => c.SubCategories)
                .HasForeignKey(sc => sc.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
