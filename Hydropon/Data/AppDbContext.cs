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
            // Specify the  database file path
            optionsBuilder.UseSqlite("Data Source=hydroponicsystem.db");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add configurations for your models if needed
            
        }
    }

}

