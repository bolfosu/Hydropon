using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydropon.Data
{
   

public class AppDbContext : DbContext
    {
        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the SQLite database file path
            optionsBuilder.UseSqlite("Data Source=hydroponicsystem.db");
        }

        // Optional: Configure database schema using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add configurations for your models if needed
            // e.g., modelBuilder.Entity<SensorReading>().HasKey(sr => sr.Id);
        }
    }

}

