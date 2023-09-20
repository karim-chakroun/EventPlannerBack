using EventPlanner.Data;
using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.WEBAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.UnitTest
{
    public class ServicesControllerUnitTest
    {
        private readonly Services _service;
        private readonly AppPlanningContext _context;
        private readonly IServServices servServices;
        static Mock<IServServices> mockServService = new Mock<IServServices>();
        private readonly string userId;
        private readonly string search;
        private readonly Guid Id;
        static ServicesController controller = new ServicesController(mockServService.Object);

        public void Init()
        {
            var Services = new List<Services>();
            mockServService.Setup(service => service.GetAll()).Returns(Services);
        }

        [Fact]
        public void TestListOfServices()
        {
            // Arrange
            Init();

            // Assert
           // Assert.NotNull(controller.GetServices()); // Ensure that the returned list is not null
        }

        [Fact]
        public void TestLatestServices()
        {
            // Arrange
            Init();

            // Assert
            Assert.NotNull(controller.GetLatestServices()); // Ensure that the returned list is not null
        }

        [Fact]
        public void TestGetEbayServices()
        {
            // Arrange
            Init();

            // Assert
            Assert.NotNull(controller.GetEbayServices(search)); // Ensure that the returned list is not null
        }

        [Fact]
        public void TestGetAmazonServices()
        {
            // Arrange
            Init();

            // Assert
            Assert.NotNull(controller.GetAmazonServices(search)); // Ensure that the returned list is not null
        }

        [Fact]
        public void TestAddService()
        {
            Mock<Services> mockService = new Mock<Services>();
            controller.Post(mockService.Object);

            mockServService.Verify(e => e.Add(It.IsAny<Services>()));
        }


    }
}
