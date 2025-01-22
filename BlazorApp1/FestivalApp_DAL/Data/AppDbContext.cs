using Microsoft.EntityFrameworkCore;
using FestivalApp_DAL.Models;

namespace FestivalApp_DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}