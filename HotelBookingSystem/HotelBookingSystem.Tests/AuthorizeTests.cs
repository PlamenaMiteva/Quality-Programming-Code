namespace HotelBookingSystem.Tests
{
    using System;
    using HotelBookingSystem.Controllers;
    using HotelBookingSystem.Identity;
    using HotelBookingSystem.Data;
    using HotelBookingSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuthorizeTests
    {
        private HotelBookingSystemData data;
        private User admin;
        private User user;
        private VenuesController venuesController;
        
        [TestInitialize]
        public void TestInit()
        {
           data = new HotelBookingSystemData();
           admin = new User("administrator", "Password123", Roles.VenueAdmin);
           user = new User("newUser", "Password123", Roles.User);
           venuesController = new VenuesController(data, admin);
        }

        [TestCleanup]
        public void TestClean()
        {
        }

        [TestMethod]
        public void Authorize_AddVanueExistingUser_ShouldReturnProfileView()
        {
            venuesController.Add("hotel", "Borovo 456", "very nice hotel");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Authorize_VenuesDetailsNonExistingUser_ShouldThrow()
        {
            data.VenuesRepository.Add(new Venue("hotel", "Borovo 456", null, null));
            var controller = new VenuesController(data, null);
            controller.Details(1);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void Authorize_VenuesDetailsNonAuthorizedUser_ShouldThrow()
        {
            data.VenuesRepository.Add(new Venue("hotel", "Borovo 456", null, null));
            var controller = new VenuesController(data, user);
            controller.Add("hotel Mirage", "Borovo 456", null);
        }

        [TestMethod]
        public void Authorize_LogoutUser_ReturnsCurrentUserIsNull()
        {
            var controller = new UsersController(data, user);

            controller.Logout();
            var result = controller.CurrentUser;

            Assert.IsNull(result);
        }
    }
}
