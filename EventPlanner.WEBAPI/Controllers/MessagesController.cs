using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventPlanner.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessageServices messageServices;

        public MessagesController(IMessageServices messageServices)
        {
            this.messageServices = messageServices;
        }

        // GET: api/<MessagesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MessagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
        [Route("GetUserMessages")]
        [HttpGet]
        public ActionResult<IEnumerable<MessagesDTO>> GetByUserId(string id)
        {
            return Ok(messageServices.GetUserMessages(id));
        }

        // POST api/<MessagesController>
        [HttpPost]
        public ActionResult<IEnumerable<Messages>> Post(Messages? m,string userId)
        {
            if (messageServices.CheckUserMessages(userId,m.SenderId).IsNullOrEmpty())
            {
                m.TimeSent = DateTime.Now;
                messageServices.Add(m);
                messageServices.Commit();
                return Ok(m);
            }
            else
                return Ok(messageServices.GetUserMessages(userId));

        }

        // PUT api/<MessagesController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Message message)
        {
            var myMessages=messageServices.GetById(id);
            message.DateMessage= DateTime.Now;
            myMessages.Message.Add(message);
            messageServices.Update(myMessages);
            messageServices.Commit();

        }

        // DELETE api/<MessagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
