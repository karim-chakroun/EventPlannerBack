using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service.DTO
{
    public class CommandGetEventDTO
    {
        public Guid IdNotification { get; set; }
        public string? Content { get; set; }
        public DateTime DateNotif { get; set; }
        public virtual UserDTO? User { get; set; }
        public virtual EventGetNotificationsDTO? Event { get; set; }
    }
}
