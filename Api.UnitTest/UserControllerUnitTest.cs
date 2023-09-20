using EventPlanner.Data;
using EventPlanner.Domain.Models;
using EventPlanner.WEBAPI.Controllers;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Api.UnitTest
{
    public class UserControllerUnitTest
    {
        private readonly ApplicationUser _user;
        private readonly AppPlanningContext _context;
        private readonly string userId;
        private readonly Guid Id;
        private UserManager<ApplicationUser> _UserManager;
        private SignInManager<ApplicationUser> _SignInManager;


        //[Fact]
        //public void TestUserRegistration()
        //{
        //    var controller = new ApplicationUserController(_UserManager, _SignInManager);
        //    Mock<ApplicationUserModel> mockUser = new Mock<ApplicationUserModel>();

        //    Assert.NotNull(controller.PostApplicationUser(mockUser.Object));


        //}

        //[Fact]
        //public void TestUserLogin()
        //{
        //    var controller = new ApplicationUserController(_UserManager, _SignInManager);
        //    Mock<LoginModel> mockUser = new Mock<LoginModel>();

        //    Assert.NotNull(controller.Login(mockUser.Object));


        //}

        [Fact]
        public void TestGetUserProfile()
        {
            var controller = new UserProfileController(_UserManager, _context);


            Assert.NotNull(controller.GetUserProfile());


        }

        [Fact]
        public void TestEditUserProfile()
        {
            var controller = new UserProfileController(_UserManager, _context);

            Mock<ApplicationUserModel> mockUser = new Mock<ApplicationUserModel>();
            Assert.NotNull(controller.EditUser(mockUser.Object));


        }




    }
}
