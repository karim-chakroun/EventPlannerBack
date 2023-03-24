using EventPlanner.Domain.Models;
using EventPlanner.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventPlanner.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        // GET: api/<NotificationController>
        [HttpGet]
        public ActionResult<IEnumerable<Notification>> Get(string? userId)
        {
            return Ok(notificationService.GetNotifications(userId));
        }

        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotificationController>
        [HttpPost]
        public void Post(List<Notification> n)
        {
            for (int i = 0;i < n.Count; i++)
            {
                notificationService.Add(n[i]);
            }
            notificationService.Commit();
        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Notification notification)
        {
            var myCommand = notificationService.GetById(id);
            myCommand.Content = notification.Content;
            notificationService.Update(myCommand);
            notificationService.Commit();
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
