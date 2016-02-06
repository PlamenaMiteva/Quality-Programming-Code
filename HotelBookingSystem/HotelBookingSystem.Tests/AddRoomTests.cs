using System.Linq;

namespace HotelBookingSystem.Tests
{
    using HotelBookingSystem.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using HotelBookingSystem.Models;
    using HotelBookingSystem.Controllers;

    [TestClass]
    public class AddRoomTests
    {
        private IHotelBookingSystemData mockedData;
        private Venue venue;
        private User user;

        [TestInitialize]
        public void TestInit()
        {
            var dataMock = new Mock<IHotelBookingSystemData>();
            var venuesRepoMock = new Mock<IRepository<Venue>>();
            var roomsRepoMock = new Mock<IRepository<Room>>();
            this.user = new User("admin", "Password1233", Roles.VenueAdmin);
            this.venue = new Venue("hotel Dreams", "addres Dreams", "desc Dreams", user);

            venuesRepoMock.Setup(v => v.Get(It.IsAny<int>())).Returns(this.venue);

            dataMock.Setup(d => d.VenuesRepository).Returns(venuesRepoMock.Object);
            dataMock.Setup(d => d.RoomsRepository).Returns(roomsRepoMock.Object);

            this.mockedData = dataMock.Object;
        }

        [TestMethod]
        public void AddRoom_ExistingVenue_ShouldAddRoom()
        {
            var controller = new RoomsController(this.mockedData, user);

            var view = controller.Add(1, 4, 245m);

            Assert.AreEqual(this.venue.Rooms.First().NumberOfPlaces, 4);
            Assert.AreEqual(this.venue.Rooms.First().PricePerDay, 245m);
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void AddRoom_NonExistingVenueId_ShouldThrow()
        {
            var controller = new RoomsController(this.mockedData, user);

            var view = controller.Add (1, 4, 245m);
        }
    }
}
