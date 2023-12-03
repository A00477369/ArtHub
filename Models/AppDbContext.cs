using Microsoft.EntityFrameworkCore;


namespace ArtHub.Models
{
    public class AppDbContext : DbContext
    {
        private static AppDbContext _instance;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    

        public static AppDbContext Instance(DbContextOptions<AppDbContext> options)
        {
            if (_instance == null)
            {
                _instance = new AppDbContext(options);
            }

            return _instance;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<Artwork> Artwork { get; set; }

    }
}
