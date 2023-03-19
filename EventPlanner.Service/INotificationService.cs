using EventPlanner.Domain.Models;
using EventPlanner.Service.DTO;
using Service.Pattern;

namespace EventPlanner.Service
{
    public interface INotificationService : IService<Notification>
    {
        public IEnumerable<GetNotificationsDTO> GetNotifications(string? userId);
    }
}
