using Microsoft.EntityFrameworkCore;
using Stores.Entities;

namespace Stores.Data
{
    public class HumanDbContext : DbContext
    {
        public HumanDbContext(DbContextOptions<HumanDbContext> options) : base(options)
        {

        }
        public DbSet<Human> Humans { get; set; }
    }
}
