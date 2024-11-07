using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydropon.Data.Models
{
    public class PlantProfile
    {
        public int Id { get; set; } // Primary key
        //list sensors
        public string Name { get; set; } // Profile name, e.g., "Tomato", "Lettuce"

        public decimal MinPH { get; set; } // Minimum acceptable pH level
        public decimal MaxPH { get; set; } // Maximum acceptable pH level

        public decimal MinEC { get; set; } // Minimum acceptable EC level
        public decimal MaxEC { get; set; } // Maximum acceptable EC level

        public TimeSpan LightOnTime { get; set; } // Time to turn lights on
        public TimeSpan LightOffTime { get; set; } // Time to turn lights off

        //public bool IsDefault { get; set; } // True for predefined profiles, false for user-created profiles

        /
     
      
    }

}
