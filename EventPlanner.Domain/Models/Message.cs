using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Domain.Models
{
    public class Message
    {
        [Key]
        public Guid IdMessage { get; set; }
        public string? Contenu { get; set; }
        public DateTime? DateMessage { get; set; }
        public Guid? IdMessages { get; set; }
        [ForeignKey("IdMessages")]
        public virtual Messages? Messages { get; set; }
        public string SenderId { get; set; }

    }
}
