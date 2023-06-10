using Microsoft.EntityFrameworkCore;
namespace RandaManga.Models
{
    class ApplicationContext:DbContext
    {
        public DbSet<Manga> Mangas { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        {
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
