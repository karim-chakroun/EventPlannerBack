using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.WEBAPI.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventPlanner.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {

        private readonly IServServices servServices;

        public ServicesController(IServServices servServices)
        {
            this.servServices = servServices;
        }


        // GET: api/<ServicesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesDTO>>> GetServices()
        {
            var services = servServices.GetAll().Select(s => new ServicesDTO
            {
                IdService = s.IdService,
                ServiceName = s.ServiceName,
                Prix = s.Prix,
                Description = s.Description,
                Promotion = s.Promotion,
                Avalable = s.Avalable,
                Image = s.Image,
                Video = s.Video,
                Notifications = s.Notifications.Select(n => new NotificationDTO
                {
                    IdNotification = n.IdNotification,
                    Content = n.Content,
                    DateNotif = n.DateNotif
                }).ToList()
            })
        .ToList();

            return Ok(services);
        }

        // GET api/<ServicesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServicesController>
        [HttpPost]
        public void Post(Services s)
        {
            servServices.Add(s);
            servServices.Commit();
        }

        // PUT api/<ServicesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
