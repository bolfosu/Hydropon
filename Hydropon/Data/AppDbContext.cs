using Microsoft.EntityFrameworkCore;
using Hydropon.Data.Models;

namespace Hydropon.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<SensorReadings> SensorReadings { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlantProfile> PlantProfiles { get; set; }


        // Use only this constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add configurations for your models if needed
        }
    }
}
