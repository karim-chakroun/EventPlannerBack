using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Domain.Models
{
    public class Feedback
    {
        [Key]
        public Guid IdFeedback { get; set; }
        public string Description { get; set; }
        public DateTime DatePost { get; set; }
        
        public string IdPoster { get; set; }
        
        public string IdReceiver { get; set; }
        public string? Fullname { get; set; }
        public string? Image { get; set; }

        [ForeignKey("IdReceiver")]
        public virtual ApplicationUser? Receiver { get; set; }
    }
}
