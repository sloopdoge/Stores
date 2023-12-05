using Microsoft.EntityFrameworkCore;
using Stores.Entities;

namespace Stores.Data
{
    public class EmployeDbContext : DbContext
    {
        public EmployeDbContext(DbContextOptions<EmployeDbContext> options) : base(options)
        {

        }
        public DbSet<Employe> Employes { get; set; }

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
        }
    }
}
