namespace EventPlanner.WEBAPI.DTO
{
    public class EventDTO
    {
        public Guid IdEvent { get; set; }
        public string EventName { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public float Cout { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Adresse { get; set; }
        public string? UserId { get; set; }
        public ICollection<NotificationDTO> Notifications { get; set; }
    }
}
