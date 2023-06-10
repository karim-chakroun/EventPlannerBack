using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using EventPlanner.Service.DTO;
using Service.Pattern;

namespace EventPlanner.Service
{
    public class EventService : Service<Events>, IEventService
    {
        public EventService(IUnitOfWork utk) : base(utk)
        {
        }

        public IEnumerable<EventDTO> GetUserEvents(string? userId)
        {
            IDatabaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);

            var events = utwk.getRepository<Events>().GetMany().Where(e => e.UserId == userId)
                .Select(e => new EventDTO
                {
                    IdEvent = e.IdEvent,
                    EventName = e.EventName,
                    DateDebut = e.DateDebut,
                    DateFin = e.DateFin,
                    Cout = e.Cout,
                    Description = e.Description,
                    Image = e.Image,
                    Adresse = e.Adresse,
                    UserId = e.UserId,
                    Notifications = e.Notifications.Select(n => new NotificationDTO
                    {
                        IdNotification = n.IdNotification,
                        Content = n.Content,
                        DateNotif = n.DateNotif
                    }).ToList()
                })
        .ToList();

            return events;
        }

        public Object getEventById(Guid? id)
        {
            IDatabaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);

            var events =  utwk.getRepository<Events>().GetById(id);

            return new
            {
                events.IdEvent,
                events.EventName,
                events.DateDebut,
                events.DateFin,
                events.Cout,
                events.Description,
                events.StepsDone,
                events.Adresse,
                events.Image,
                ExternServices = events.ExternServices.Select(n => new ExternServices
                {
                    serviceName = n.serviceName,
                    prix=n.prix,
                    lien=n.lien,
                    provider=n.provider,
                    

                }).ToList(),
                Notifications = events.Notifications.Select(n => new GetNotificationsDTO
                {
                    IdNotification = n.IdNotification,
                    Content = n.Content,
                    DateNotif = n.DateNotif,
                    Service = new ServiceGetNotificationDTO
                    {
                        ServiceName = n.Service.ServiceName,
                        Description= n.Service.Description,
                        Prix=n.Service.Prix,
                        Image=n.Service.Image,
                        Promotion=n.Service.Promotion,
                        Type=n.Service.Type,

                        
                    },

                }).ToList()

            };
        }

        public IEnumerable<Events> GetEventsWithNotif()
        {
            IDatabaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            return utwk.getRepository<Events>().GetMany(e => e.Notifications != null).Distinct();
        }
    }
}
