using FestivalApp_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalApp_DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Festival> Festivals { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=festivalapp.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                .HasIndex(g => g.Email)
                .IsUnique();

            modelBuilder.Entity<Artist>()
                .HasIndex(a => a.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}