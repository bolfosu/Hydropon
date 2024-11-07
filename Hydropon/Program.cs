using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder; // Required for application builder
using Microsoft.AspNetCore.Hosting; // Required for web hosting
using Hydropon.Data;
using Hydropon.Core;

namespace Hydropon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DockerTest dockerTest = new DockerTest();
            dockerTest.Test();

            var builder = WebApplication.CreateBuilder(args); // Use WebApplication instead of Host

            // Configure app configuration
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Configure services
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers(); // Register controllers

            var app = builder.Build(); // Build the app

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Use developer exception page
            }

            app.UseRouting(); // Use routing middleware

            app.UseEndpoints(endpoints => // Configure endpoints
            {
                endpoints.MapControllers(); // Map controller routes
            });

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                try
                {
                    dbContext.Database.EnsureCreated();
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while migrating or seeding the database: {ex.Message}");
                }
            }
            app.Urls.Add("http://localhost:5001");
            app.Run(); // Run the application
        }
    }
}
