namespace HotelBookingSystem.Tests
{
    using System;
    using HotelBookingSystem.Controllers;
    using HotelBookingSystem.Data;
    using HotelBookingSystem.Identity;
    using HotelBookingSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LogoutTests
    {
        private HotelBookingSystemData data;
        private User admin;
        private User user;
        private UsersController usersController;

        [TestInitialize]
        public void TestInit()
        {
            data = new HotelBookingSystemData();
            admin = new User("administrator", "Password123", Roles.VenueAdmin);
            user = new User("newUser", "Password123", Roles.User);
            usersController = new UsersController(data, admin);
        }

        [TestCleanup]
        public void TestClean()
        {
        }

        [TestMethod]
        public void Logout_LogoutExistingAdminUser_ShouldLogoutUser()
        {
            usersController.Logout();

            var result = usersController.CurrentUser;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Logout_LogoutExistingUser_ShouldLogoutUser()
        {
            var controller = new UsersController(data, user);

            controller.Logout();
            var result = controller.CurrentUser;

            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Logout_LogoutNonExistingUser_ShouldThrow()
        {
            var controller = new UsersController(data, null);
            controller.Logout();
        }
    }
}
