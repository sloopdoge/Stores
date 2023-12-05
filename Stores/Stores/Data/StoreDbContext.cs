using Microsoft.EntityFrameworkCore;
using Stores.Entities;

namespace Stores.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
               .HasOne(s => s.OwnerHuman)
               .WithMany()
               .HasForeignKey(s => s.Owner)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
