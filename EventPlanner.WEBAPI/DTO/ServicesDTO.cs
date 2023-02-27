using EventPlanner.Domain.Models;

namespace EventPlanner.WEBAPI.DTO
{
    public class ServicesDTO
    {
        public Guid IdService { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public bool Avalable { get; set; }
        public int Promotion { get; set; }
        public string? Type { get; set; }
        public float Prix { get; set; }
        public string? Image { get; set; }
        public string? Video { get; set; }
        public virtual ICollection<NotificationDTO>? Notifications { get; set; }
    }
}
