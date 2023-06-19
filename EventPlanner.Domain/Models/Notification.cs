using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanner.Domain.Models
{
    public class Notification
    {
        [Key]
        public Guid IdNotification { get; set; }
        public Guid ServiceFk { get; set; }
        public Guid EventFk { get; set; }
        public string? UserFk { get; set; }
        public string? IdRequester { get; set; }
        public string? IdProvider { get; set; }
        public string? Content { get; set; }
        public int? Quantity { get; set; }
        public string? State { get; set; }
        public bool? Closed { get; set; }
        public DateTime DateNotif { get; set; }

        [ForeignKey("ServiceFk")]
        //[JsonIgnore]
        public virtual Services? Service { get; set; }

        [ForeignKey("EventFk")]
        public virtual Events? Event { get; set; }
        //[JsonIgnore]
        [ForeignKey("UserFk")]
        public virtual ApplicationUser? User { get; set; }
    }
}
