using Microsoft.EntityFrameworkCore;

namespace SampleDockerApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=sqlserver;Database=SampleDb;User Id=sa;Password=Your_password123;");
            }
        }
    }
}
