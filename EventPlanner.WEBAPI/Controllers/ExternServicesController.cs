using EventPlanner.Domain.Models;
using EventPlanner.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventPlanner.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternServicesController : ControllerBase
    {

        private readonly IExternServices externServices;

        public ExternServicesController(IExternServices externServices)
        {
            this.externServices = externServices;
        }

        // GET: api/<ExternServicesController>
        [HttpGet]
        public IEnumerable<ExternServices> Get()
        {
            return externServices.GetAll();
        }

        // GET api/<ExternServicesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExternServicesController>
        [HttpPost]
        public void Post(List<ExternServices> n)
        {
            for (int i = 0; i < n.Count; i++)
            {
                externServices.Add(n[i]);
            }
            externServices.Commit();
        }

        // PUT api/<ExternServicesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExternServicesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
