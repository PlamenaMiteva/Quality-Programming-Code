namespace HotelBookingSystem.Tests
{
    using HotelBookingSystem.Controllers;
    using HotelBookingSystem.Data;
    using HotelBookingSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;
    using System.Collections.Generic;

    [TestClass]
    public class AllVenuesTests
    {
        private HotelBookingSystemData data;
        private VenuesController venuesController;
        private User user;

        [TestInitialize]
        public void TestInit()
        {
            data = new HotelBookingSystemData();
            user = new User("newUser", "Password123", Roles.VenueAdmin);
            venuesController = new VenuesController(data, user);
        }

        [TestCleanup]
        public void TestClean()
        {
        }

        [TestMethod]
        public void All_AllVenuesWithExistingItems_ShouldReturnAllVenues()
        {
            var venues = new List<Venue>();
            var venue1 = new Venue("hotel1", "Address1", "description1", null);
            var venue2 = new Venue("hotel2", "Address2", "description2", null);
            var venue3 = new Venue("hotel3", "Address3", "description3", user);
            venues.Add(venue1);
            venues.Add(venue2);
            venues.Add(venue3);

            venuesController.Add("hotel1", "Address1", "description1");
            venuesController.Add("hotel2", "Address2", "description2");
            venuesController.Add("hotel3", "Address3", "description3");

            var idCounter = 1;
            StringBuilder expected = new StringBuilder();
            foreach (var venue in venues)
            {
                var venueInfo = string.Format("*[{0}] {1}, located at {2}", idCounter++, venue.Name, venue.Address);
                var venueFreeRoomsInfo = string.Format("Free rooms: {0}", venue.Rooms.Count);
                expected.AppendLine(venueInfo).AppendLine(venueFreeRoomsInfo);
            }

            var result = venuesController.All().Display();

            Assert.AreEqual(expected.ToString().Trim(), result);
        }
    }
}
