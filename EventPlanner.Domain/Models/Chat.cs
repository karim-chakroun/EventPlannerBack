﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Domain.Models
{
    public class Chat
    {
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }
        public DateTime TimeSent { get; set; }
    }

}
