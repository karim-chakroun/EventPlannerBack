using EventPlanner.Data;
using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.WEBAPI.Controllers;
using EventPlanner.WEBAPI.DTO;
using EventPlanner.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.UnitTest
{
    public class EventControllerUnitTest
    {
        private readonly Events _event;
        private readonly AppPlanningContext _context;
        private readonly IEventService eventService;
        static Mock<IEventService> mockEventService = new Mock<IEventService>();
        private readonly string userId;
        private readonly Guid Id;

        //static Mock<EventController> mockEventController = new Mock<EventController>();
        static EventController controller = new EventController(mockEventService.Object);

        public void Init()
        {
            var events = new List<Events>();
            mockEventService.Setup(service => service.GetAll()).Returns(events);
        }

        [Fact]
        public void TestListOfEvents()
        {
            // Arrange
            Init();
            
            // Assert
            Assert.NotNull(controller.GetEvents()); // Ensure that the returned list is not null
        }



        [Fact]
        public void TestAddEvent()
        {
            Mock<Events> mockEvent = new Mock<Events>();
            controller.Post(mockEvent.Object);

            mockEventService.Verify(e=>e.Add(It.IsAny<Events>()));

        }

        [Fact]
        public void TestGetUserEvents()
        {
            // Arrange
            var events = new List<EventPlanner.Service.DTO.EventDTO>();
            mockEventService.Setup(service => service.GetUserEvents(userId)).Returns(events);


            // Assert
            Assert.NotNull(controller.GetUserEvents(userId)); // Ensure that the returned list is not null
        }

        [Fact]
        public void TestUpdateEvent()
        {
            Mock<Events> mockEvent = new Mock<Events>();

            Assert.NotNull(mockEventService.Setup(service => service.Update(mockEvent.Object)));

        }





    }
}
