using EventPlanner.Domain.Models;

namespace EventPlanner.Service.DTO
{
    public class NotificationDTO
    {
        public Guid IdNotification { get; set; }
        public string? Content { get; set; }
        public DateTime DateNotif { get; set; }
        public virtual UserDTO? User { get; set; }
    }
}
