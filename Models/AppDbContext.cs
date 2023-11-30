using Microsoft.EntityFrameworkCore;
using ArtHub.Models;


namespace ArtHub.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Category> Category { get; set; }
	}
}
