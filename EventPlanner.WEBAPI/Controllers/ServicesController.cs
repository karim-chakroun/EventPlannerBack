﻿using EventPlanner.Domain.Models;
using EventPlanner.Service;
//using EventPlanner.WEBAPI.DTO;
using EventPlanner.Service.DTO;
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
        public ActionResult<IEnumerable<ServicesDTO>> GetLatestServices()
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
                UserId = s.UserId,
                Provider = "INTERN",
                Notifications = s.Notifications.Select(n => new NotificationGetServicesDTO
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
        [Route("GetUserServices")]
        public ActionResult<IEnumerable<ServicesDTO>> GetUserServices(string userId)
        {
            var services = servServices.GetAll().Where(s => s.UserId == userId).Select(s => new ServicesDTO
            {
                IdService = s.IdService,
                ServiceName = s.ServiceName,
                Prix = s.Prix,
                Description = s.Description,
                Promotion = s.Promotion,
                Avalable = s.Avalable,
                Type = s.Type,
                Image = s.Image,
                Video = s.Video,
                UserId = s.UserId,
                Provider = "INTERN",
                Notifications = s.Notifications.Select(n => new NotificationGetServicesDTO
                {
                    IdNotification = n.IdNotification,
                    Content = n.Content,
                    DateNotif = n.DateNotif
                }).ToList()
            })
        .ToList();

            return Ok(services);
        }

        // GET: api/<ServicesController>
        [HttpGet]
        public ActionResult<IEnumerable<ServicesDTO>> GetServices()
        {
            var services = servServices.GetAll().Select(s => new ServicesDTO
            {
                IdService = s.IdService,
                ServiceName = s.ServiceName,
                Prix = s.Prix,
                Description = s.Description,
                Promotion = s.Promotion,
                Avalable = s.Avalable,
                Type= s.Type,
                Image = s.Image,
                Video = s.Video,
                UserId = s.UserId,
                Provider = "INTERN",
                Notifications = s.Notifications.Select(n => new NotificationGetServicesDTO
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
        public async Task<List<ServicesDTO>> GetEbayServices(string? search)
        {
            List<ServicesDTO> Datalst = new List<ServicesDTO>();

            HttpClient hc = new HttpClient();
            HttpResponseMessage result = await hc.GetAsync($"https://www.ebay.fr/sch/i.html?_from=R40&_nkw=" + search + "&_sacat=0&_ipg=240");
            Stream stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(stream);
            HtmlNodeCollection? HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='s-item__title']");
            HtmlNodeCollection? Descriptions = doc.DocumentNode.SelectNodes("//div[@class='s-item__subtitle']");
            HtmlNodeCollection? Prices = doc.DocumentNode.SelectNodes("//span[@class='s-item__price']");// var cammelcase
            HtmlNodeCollection? Image = doc.DocumentNode.SelectNodes("//div[@class='s-item__image-wrapper image-treatment']/img");



            if (HeaderNames != null)
            {
                for (int i = 0; i < HeaderNames.Count; i++)
                {
                    var serviceName = HeaderNames[i].InnerText.Trim();
                    var description = Descriptions[i]?.InnerText?.Trim();
                    var priceText = Prices[i]?.InnerText?.Trim();
                    var image = Image[i]?.Attributes["src"]?.Value?.Trim();
                    float price = 0;

                    //replaced
                    string substringToRemove = "<!--F#f_0-->";
                    string substringEndToRemove = "<!--F/-->";

                    if (!string.IsNullOrEmpty(priceText))
                    {
                        // Remove currency symbol and thousands separator if present
                        priceText = priceText.Replace("€", "").Replace(".", "").Replace("EUR", "").Replace("à", "").Replace(substringToRemove, "").Replace(substringEndToRemove, ""); ;

                        Console.WriteLine($"priceText: {priceText}");

                        if (float.TryParse(priceText, out float parsedPrice))
                        {
                            price = parsedPrice;
                        }
                        
                        serviceName = serviceName.Replace(substringToRemove, "").Replace(substringEndToRemove,"");
                        description = description.Replace(substringToRemove, "").Replace(substringEndToRemove, "");

                        Console.WriteLine($"parsedPrice: {parsedPrice}");
                    }

                    var service = new ServicesDTO
                    {
                        ServiceName = serviceName,
                        Description = description,
                        Prix = price,
                        Image = image,
                        Provider = "EBAY",
                        Type = search

                    };

                    Datalst.Add(service);
                }
                Datalst.RemoveAt(0);
            }


            return Datalst;
        }

        [Route("Amazon")]
        [HttpGet]
        public async Task<List<ServicesDTO>> GetAmazonServices(string? search)
        {
            List<ServicesDTO> Datalst = new List<ServicesDTO>();

            HttpClient hc = new HttpClient();
            HttpResponseMessage result = await hc.GetAsync($"https://www.amazon.fr/s?k=" + search);
            Stream stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(stream);
            
            HtmlNodeCollection? HeaderNames = doc.DocumentNode.SelectNodes("//span[@class='a-size-base-plus a-color-base a-text-normal']");
            HtmlNodeCollection? Descriptions = doc.DocumentNode.SelectNodes("//span[@class='a-icon-alt']");
            HtmlNodeCollection? Prices = doc.DocumentNode.SelectNodes("//span[@class='a-price-whole']");

            HtmlNodeCollection? Image = doc.DocumentNode.SelectNodes("//div[@class='a-section aok-relative s-image-square-aspect']/img");

            if (Prices != null)
            {
                for (int i = 0; i < Prices.Count; i++)
                {
                    var serviceName = HeaderNames[i].InnerText.Trim();
                    var description = Descriptions[i]?.InnerText?.Trim();
                    var priceText = Prices[i]?.InnerText?.Trim();
                    var image = Image[i]?.Attributes["src"]?.Value?.Trim();
                    float price = 0;
                    //Console.WriteLine($"priceText: {serviceName}");

                    if (!string.IsNullOrEmpty(priceText))
                    {
                        // Remove currency symbol and thousands separator if present
                        priceText = priceText;

                        Console.WriteLine($"priceText: {priceText}");

                        if (float.TryParse(priceText, out float parsedPrice))
                        {
                            price = parsedPrice;
                        }

                        Console.WriteLine($"parsedPrice: {parsedPrice}");
                    }



                    var service = new ServicesDTO
                    {
                        ServiceName = serviceName,
                        Description = description,
                        Image = image,
                        Prix= price,
                
                        Provider = "AMAZON",
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
        public void Delete(Guid id)
        {
            ;
            servServices.Delete(servServices.GetById(id));
            servServices.Commit();
        }

        [HttpGet]
        [Route("stats")]
        public async Task<Object> getstats(string userId)
        {
            var services = servServices.GetAll().Where(s => s.UserId == userId).Select(s => new stats
            {
               name=s.ServiceName,
               value=s.Notifications.Count()
            })
        .ToList();

            return Ok(services);
        }
    }
}
