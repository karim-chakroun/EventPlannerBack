using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Service
{
    public class NotificationService : Service<Notification>, INotificationService
    {
        public NotificationService(IUnitOfWork utk) : base(utk)
        {
        }
    }
}
