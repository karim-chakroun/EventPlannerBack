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
    public interface IEventService : IService<Events>
    {
        public IEnumerable<Events> GetEventsWithNotif();
        public IEnumerable<EventDTO> GetUserEvents(string userId);
    }
}
