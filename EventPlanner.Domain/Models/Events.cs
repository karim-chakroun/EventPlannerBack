using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Domain.Models
{
    public class Events
    {
        [Key]
        public Guid IdEvent { get; set; }
        public string? EventName { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public float Cout { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } 
        public string? Adresse { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
