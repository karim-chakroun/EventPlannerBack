﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? Adresse { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
    }
}
