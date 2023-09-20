using EventPlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service.DTO
{
    public class ParticipationDTO
    {
        public Guid IdParticipation { get; set; }
        public string? IdUser { get; set; }
        public Guid? IdEvent { get; set; }
        public string? UserName { get; set; }
        public string? Image { get; set; }

    }
}
