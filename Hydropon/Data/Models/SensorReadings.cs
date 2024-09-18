using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydropon.Data.Models
{
    public class SensorReadings
    {
      
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public double PH { get; set; }
        public double EC { get; set; }
        public double WaterTemperature { get; set; }
        public double LightIntensity { get; set; }

    }
}

