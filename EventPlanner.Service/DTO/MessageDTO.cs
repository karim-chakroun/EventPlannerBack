using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service.DTO
{
    public class MessageDTO
    {
        public Guid IdMessage { get; set; }
        public string? Contenu { get; set; }
        public DateTime DateMessage { get; set; }
        public Guid IdMessages { get; set; }
        public string SenderId { get; set; }
    }
}
