using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add configurations for your models if needed
            
        }
    }

}

