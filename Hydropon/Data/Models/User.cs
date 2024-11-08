﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydropon.Data.Models
{
    public class User
    {
        public int Id { get; set; } // Primary key

        public string Username { get; set; } // Username
        public string PasswordHash { get; set; } // Hashed password
        //email
        //security question
        //phone number
        public ICollection<PlantProfile> PlantProfiles { get; set; } // Profiles created by the user
        
        
    }

}
