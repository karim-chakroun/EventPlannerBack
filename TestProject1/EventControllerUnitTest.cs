using EventPlanner.Data;
using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.WEBAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class EventControllerUnitTest
    {
        private readonly Events _event;
        private readonly AppPlanningContext _context;
        private readonly IEventService eventService;


        [Fact]
        public void ShouldReturnListOfExemple()
        {
            //Arrange// //Appel notre controlleur//
            var controller = new EventController(eventService);


            //Act// //execute notre controlleur//

            var result = controller.GetEvents();
            //Assert//
            Xunit.Assert.NotNull(result); // not null//

        }
    }
}
