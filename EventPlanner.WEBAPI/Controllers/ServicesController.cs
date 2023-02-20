using EventPlanner.Domain.Models;
using EventPlanner.Service;
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
        public IEnumerable<Services> Get()
        {
            return servServices.GetAll();
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
