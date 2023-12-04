using Microsoft.EntityFrameworkCore;
using Stores.Entities;

namespace Stores.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>()
                .HasOne(e => e.Human)
                .WithMany()
                .HasForeignKey(e => e.HumanID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employe>()
                .HasOne(e => e.Store)
                .WithMany(s => s.Employes)
                .HasForeignKey(e => e.StoreID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SubCategory>()
               .HasOne(sc => sc.Category)
               .WithMany(c => c.SubCategories)
                .HasForeignKey(sc => sc.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity<Store>()
               .HasOne(s => s.OwnerHuman)
               .WithMany()
               .HasForeignKey(s => s.Owner)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
