﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hydropon.Data; // Ensure you have the correct namespace for your AppDbContext

namespace Hydropon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    // Configure DbContext with SQLite connection
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnection")));

                    // Add other services here, if necessary
                });

            var app = builder.Build();

            // Ensure database is created and migrations are applied
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                try
                {
                    dbContext.Database.EnsureCreated(); // This ensures the database is created if it doesn't exist
                    dbContext.Database.Migrate(); // This applies any pending migrations
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while migrating or seeding the database: {ex.Message}");
                }
            }

            app.Run();
        }
    }
}
