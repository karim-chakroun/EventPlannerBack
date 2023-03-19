using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using EventPlanner.Service.DTO;
using Service.Pattern;

namespace EventPlanner.Service
{
    public class NotificationService : Service<Notification>, INotificationService
    {
        public NotificationService(IUnitOfWork utk) : base(utk)
        {
        }

        public IEnumerable<GetNotificationsDTO> GetNotifications(string? userId)
        {
            IDatabaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);

            var notifications = utwk.getRepository<Notification>().GetMany().Where(n=>n.IdProvider==userId)
                .Select(n => new GetNotificationsDTO
                {
                    IdNotification = n.IdNotification,
                    Content = n.Content,
                    DateNotif = n.DateNotif,
                    User = new UserDTO
                    {
                        Id = n.User?.Id,
                        Email = n.User?.Email,
                        FullName = n.User?.FullName,
                        PhoneNumber = n.User?.PhoneNumber
                    },
                    Event = new EventGetNotificationsDTO
                    {
                        IdEvent = n.Event.IdEvent,
                        EventName = n.Event.EventName,
                        DateDebut = n.Event.DateDebut,
                        DateFin = n.Event.DateFin,
                        Cout = n.Event.Cout,
                        Description = n.Event?.Description,
                        Image = n.Event?.Image,
                        Adresse = n.Event?.Adresse,
                        UserId = n.Event?.UserId
                    },
                    Service = new ServiceGetNotificationDTO
                    {
                        IdService = n.Service.IdService,
                        ServiceName = n.Service.ServiceName,
                        Prix = n.Service.Prix,
                        Avalable = n.Service.Avalable,
                        Promotion = n.Service.Promotion,
                        Description = n.Service?.Description,
                        Image = n.Service?.Image,
                        Type = n.Service?.Type,
                        Video = n.Service?.Video
                    }
                }

                    ).ToList();

            return notifications;
        }
    }
}
