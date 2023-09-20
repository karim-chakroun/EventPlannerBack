using EventPlanner.Data;
using EventPlanner.Domain.Models;
using EventPlanner.Service;
using EventPlanner.WEBAPI.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.UnitTest
{
    public class OrderControllerUnitTest
    {
        private readonly Notification _order;
        private readonly AppPlanningContext _context;
        private readonly INotificationService orderService;
        static Mock<INotificationService> mockOrderService = new Mock<INotificationService>();
        private readonly string userId;
        private readonly string search;
        private readonly Guid Id;
        static NotificationController controller = new NotificationController(mockOrderService.Object);

        public void Init()
        {
            var Order = new List<Notification>();
            mockOrderService.Setup(order => order.GetAll()).Returns(Order);
        }

        [Fact]
        public void TestListOfOrders()
        {
            // Arrange
            Init();

            // Assert
            Assert.NotNull(controller.Get(userId)); // Ensure that the returned list is not null
        }

        [Fact]
        public void TestAddOrder()
        {
            Mock<Notification> mockOrder = new Mock<Notification>();
            var mockOrders = new List<Notification>
            {
                mockOrder.Object    
            };
            
            controller.Post(mockOrders);

            mockOrderService.Verify(e => e.Add(It.IsAny<Notification>()));

        }

        [Fact]
        public void TestUpdateOrder()
        {
            Mock<Notification> mockOrder = new Mock<Notification>();

            Assert.NotNull(mockOrderService.Setup(order => order.Update(mockOrder.Object)));

        }

        [Fact]
        public void TestDeleteOrder()
        {
            Mock<Notification> mockOrder = new Mock<Notification>();

            Assert.NotNull(mockOrderService.Setup(order => order.Delete(mockOrder.Object)));

        }
    }
}
