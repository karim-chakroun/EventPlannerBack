using EventPlanner.Domain.Models;
using EventPlanner.Service.DTO;
using Service.Pattern;

namespace EventPlanner.Service
{
    public interface IEventService : IService<Events>
    {
        public IEnumerable<Events> GetEventsWithNotif();
        public IEnumerable<EventDTO> GetUserEvents(string userId);
        public Object getEventById(Guid? id);
    }
}
