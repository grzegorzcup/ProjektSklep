using Microsoft.EntityFrameworkCore;
using ProjektSklep.Models;


namespace ProjektSklep.Data
{
    public class ProjektSklepContext : DbContext
    {
        public ProjektSklepContext(DbContextOptions<ProjektSklepContext> options) : base(options) { }
        public DbSet<ProjektSklep.Models.Product> Products { get; set; } = default!;
        public DbSet<ProjektSklep.Models.Client> Clients { get; set; } = default!;
        public DbSet<ProjektSklep.Models.Order> Orders { get; set; } = default!;
        public DbSet<ProjektSklep.Models.OrderProduct> OrderProducts { get; set; } = default!;
        public DbSet<ProjektSklep.Models.Category> Categories { get; set; } = default!;
    }
}
