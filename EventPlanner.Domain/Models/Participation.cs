using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Domain.Models
{
    public class Participation
    {
        [Key]
        public Guid IdParticipation { get; set; }
        public string? IdUser { get; set; }
        public Guid? IdEvent { get; set; }
        public string? UserName { get; set; }
        public string? Image { get; set; }

        [ForeignKey("IdEvent")]
        public virtual Events? Event { get; set; }
    }
}
