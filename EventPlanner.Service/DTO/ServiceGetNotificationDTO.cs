﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service.DTO
{
    public class ServiceGetNotificationDTO
    {
        public Guid IdService { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public bool Avalable { get; set; }
        public int Promotion { get; set; }
        public string? Type { get; set; }
        public float Prix { get; set; }
        public string? Image { get; set; }
        public string? Video { get; set; }
    }
}
