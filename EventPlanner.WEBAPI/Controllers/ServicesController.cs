using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.WEBAPI.DTO;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Route("GetLatestServices")]
        [HttpGet]
        public ActionResult<IEnumerable<ServicesDto>> GetLatestServices()
        {
            var services = servServices.GetAll().Select(s => new ServicesDto
            {
                IdService = s.IdService,
                ServiceName = s.ServiceName,
                Prix = s.Prix,
                Description = s.Description,
                Promotion = s.Promotion,
                Avalable = s.Avalable,
                Image = s.Image,
                Video = s.Video,
                Provider = "INTERN",
                Notifications = s.Notifications.Select(n => new NotificationDTO
                {
                    IdNotification = n.IdNotification,
                    Content = n.Content,
                    DateNotif = n.DateNotif
                }).ToList()
            })
                .Take(3)
        .ToList();

            return Ok(services);
        }

        // GET: api/<ServicesController>
        [HttpGet]
        public ActionResult<IEnumerable<ServicesDto>> GetServices()
        {
            var services = servServices.GetAll().Select(s => new ServicesDto
            {
                IdService = s.IdService,
                ServiceName = s.ServiceName,
                Prix = s.Prix,
                Description = s.Description,
                Promotion = s.Promotion,
                Avalable = s.Avalable,
                Image = s.Image,
                Video = s.Video,
                Provider = "INTERN",
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
        [Route("Ebay")]
        [HttpGet]
        public async Task<List<ServicesDto>> GetEbayServices(string? search)
        {
            List<ServicesDto> Datalst = new List<ServicesDto>();

            HttpClient hc = new HttpClient();
            HttpResponseMessage result = await hc.GetAsync($"https://www.ebay.fr/sch/i.html?_from=R40&_nkw=" + search + "&_sacat=0&_ipg=240");
            Stream stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(stream);
            HtmlNodeCollection? HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='s-item__title']");
            HtmlNodeCollection? Descriptions = doc.DocumentNode.SelectNodes("//div[@class='s-item__subtitle']");
            HtmlNodeCollection? Prices = doc.DocumentNode.SelectNodes("//span[@class='s-item__price']");// var cammelcase


            if (HeaderNames != null)
            {
                for (int i = 0; i < HeaderNames.Count; i++)
                {
                    var serviceName = HeaderNames[i].InnerText.Trim();
                    var description = Descriptions[i]?.InnerText?.Trim();
                    var priceText = Prices[i]?.InnerText?.Trim();
                    float price = 0;

                    if (!string.IsNullOrEmpty(priceText))
                    {
                        // Remove currency symbol and thousands separator if present
                        priceText = priceText.Replace("€", "").Replace(".", "").Replace("EUR", "").Replace("à", "");

                        Console.WriteLine($"priceText: {priceText}");

                        if (float.TryParse(priceText, out float parsedPrice))
                        {
                            price = parsedPrice;
                        }

                        Console.WriteLine($"parsedPrice: {parsedPrice}");
                    }

                    var service = new ServicesDto
                    {
                        ServiceName = serviceName,
                        Description = description,
                        Prix = price,
                        Provider = "EBAY",
                        Type = search

                    };

                    Datalst.Add(service);
                }
            }


            return Datalst;
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
