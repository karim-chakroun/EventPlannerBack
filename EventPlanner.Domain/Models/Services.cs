using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Domain.Models
{
    public class Services
    {
        [Key]
        public Guid IdService { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public bool Avalable { get; set; }
        public int Promotion { get; set; }
        public string Type { get; set; }
        public float Prix { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
