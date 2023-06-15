using EventPlanner.Domain.Models;
using EventPlanner.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventPlanner.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        // GET: api/<FeedbackController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FeedbackController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FeedbackController>
        [HttpPost]
        public Feedback Post(Feedback f)
        {
            feedbackService.Add(f);
            feedbackService.Commit();
            return feedbackService.GetById(f.IdFeedback);
        }

        // PUT api/<FeedbackController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FeedbackController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
