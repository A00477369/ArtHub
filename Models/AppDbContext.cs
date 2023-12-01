using Microsoft.EntityFrameworkCore;
using ArtHub.Models;
using System;

namespace ArtHub.Models
{
    public class AppDbContext : DbContext
    {
            
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; } // Ensure pluralization for consistency

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
