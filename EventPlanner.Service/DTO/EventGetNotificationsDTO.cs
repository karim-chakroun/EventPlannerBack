using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service.DTO
{
    public class EventGetNotificationsDTO
    {
        public Guid IdEvent { get; set; }
        public string? EventName { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public float Cout { get; set; }
        public bool StepsDone { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Adresse { get; set; }
        public string? UserId { get; set; }
    }
}
