using EventPlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service.DTO
{
    public class MessagesDTO
    {
        public Guid? MessageId { get; set; }
        public string? SenderId { get; set; }
        public string? SenderName { get; set; }
        public string? ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public virtual List<MessageDTO>? Message { get; set; }
        public DateTime? TimeSent { get; set; }
    }
}
