using Hydropon.Data.Models;
using Hydropon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydropon.Services
{
    public class SensorService
    {
        private readonly AppDbContext _context;

        public SensorService(AppDbContext context)
        {
            _context = context;
        }

        // Replace this with your actual sensor reading logic
        private (double PH, double EC, double WaterTemperature) ReadSensorData()
        {
            // Placeholder: Replace with actual sensor data fetching logic
            float ph = 6.5f; // Example pH value
            float ec = 1.2f; // Example EC value
            float temperature = 24.5f; // Example temperature value
            return (ph, ec, temperature);
        }

        public async Task LogSensorDataAsync()
        {
            var sensorData = ReadSensorData();

            var reading = new SensorReadings
            {
                Timestamp = DateTime.Now,
                PH = sensorData.PH,
                EC = sensorData.EC,
                WaterTemperature = sensorData.WaterTemperature
            };

            await _context.SensorReadings.AddAsync(reading);
            await _context.SaveChangesAsync();
        }
    }
}
