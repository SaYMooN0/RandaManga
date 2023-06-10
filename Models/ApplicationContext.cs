using Microsoft.EntityFrameworkCore;
namespace RandaManga.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Manga> MangaCatalog { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
