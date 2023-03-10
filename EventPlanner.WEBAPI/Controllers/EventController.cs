using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.WEBAPI.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventPlanner.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        // GET: api/<EventController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetEvents()
        {
            var events = eventService.GetAll().Select(e => new EventDTO
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

            return Ok(events);
        }

        [HttpGet]
        [Route("GetUserEvents")]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetUserEvents(string? userId)
        {
            return Ok(eventService.GetUserEvents(userId));
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventController>
        [HttpPost]
        public Events Post(Events e)
        {
            eventService.Add(e);
            eventService.Commit();
            return eventService.GetById(e.IdEvent);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
