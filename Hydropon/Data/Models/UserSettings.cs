using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydropon.Data.Models
{
    public class UserSettings
    {
        
            public int Id { get; set; } // Primary key

            public int UserId { get; set; } // Foreign key to the user
            public User User { get; set; } // Navigation property to the user

            public int DefaultPlantProfileId { get; set; } // Foreign key to the default plant profile
            public PlantProfile DefaultPlantProfile { get; set; } // Navigation property to the plant profile

            public bool NotificationsEnabled { get; set; } // Enable/Disable notifications
            public string NotificationEmail { get; set; } // Email address for notifications
            public bool NotifyOnPHThreshold { get; set; } // Notify if pH goes out of range
            public bool NotifyOnECThreshold { get; set; } // Notify if EC goes out of range
            public bool NotifyOnWaterLevelLow { get; set; } // Notify if water level is low
            public bool NotifyOnSystemFailure { get; set; } // Notify on system failure

           
        }


    }

