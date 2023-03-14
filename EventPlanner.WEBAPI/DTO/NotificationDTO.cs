namespace EventPlanner.WEBAPI.DTO
{
    public class NotificationDTO
    {
        public Guid IdNotification { get; set; }
        public string? Content { get; set; }
        public DateTime DateNotif { get; set; }
    }
}
