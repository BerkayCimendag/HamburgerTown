using Microsoft.EntityFrameworkCore;

namespace HamburgerTown.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Hamburger> Hamburgers => Set<Hamburger>();
        public DbSet<Beverage> Beverages => Set<Beverage>();
        public DbSet<ExtraSupply> ExtraSupplies => Set<ExtraSupply>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Size> Sizes => Set<Size>();
    }
}
