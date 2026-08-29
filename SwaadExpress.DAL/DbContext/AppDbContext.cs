using Microsoft.EntityFrameworkCore;
using SwaadExpress.Domain.Modal.Entity;
namespace SwaadExpress.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }

        //public DbSet<Product> Products { get; set; } = null!;
     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Register the configuration here

            // or automatically apply all configurations in the assembly:
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(YourDbContext).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
    }
