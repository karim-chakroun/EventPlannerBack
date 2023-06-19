using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Domain.Models
{
    public class ExternServices
    {
        [Key]
        public Guid IdExternServices { get; set; }
        public string? serviceName { get; set; }
        public string? lien { get; set; }
        public string? provider { get; set; }
        public float? prix { get; set; }
        public int? Quantity { get; set; }
        public bool avalable { get; set; }
        public Guid EventFk { get; set; }
        [ForeignKey("EventFk")]
        public virtual Events? Event { get; set; }
    }
}
