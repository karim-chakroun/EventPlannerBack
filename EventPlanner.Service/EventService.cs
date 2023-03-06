using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using EventPlanner.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var events = utwk.getRepository<Events>().GetMany().Where(e => e.UserId==userId)
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

        public IEnumerable<Events> GetEventsWithNotif()
        {
            IDatabaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            return utwk.getRepository<Events>().GetMany(e => e.Notifications != null).Distinct();
        }
    }
}
