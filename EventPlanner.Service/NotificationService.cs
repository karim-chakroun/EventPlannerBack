using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using Service.Pattern;

namespace EventPlanner.Service
{
    public class NotificationService : Service<Notification>, INotificationService
    {
        public NotificationService(IUnitOfWork utk) : base(utk)
        {
        }
    }
}
