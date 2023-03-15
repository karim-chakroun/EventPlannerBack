using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Domain.Models
{
    public class Events
    {
        [Key]
        public Guid IdEvent { get; set; }
        public string? EventName { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public float Cout { get; set; }
        public bool StepsDone { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Adresse { get; set; }
        public string? UserId { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<ExternServices>? ExternServices { get; set; }
    }
}
