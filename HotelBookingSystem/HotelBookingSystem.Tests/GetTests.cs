namespace HotelBookingSystem.Tests
{
    using HotelBookingSystem.Data;
    using HotelBookingSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetTests
    {
        private UserRepository usersRepo;

        [TestInitialize]
        public void TestInit()
        {
            usersRepo = new UserRepository();
        }

        [TestCleanup]
        public void TestClean()
        {
        }

        [TestMethod]
        public void Get_GetExistingItem_ShouldReturnItem()
        {
            var user = new User("plamena", "Password123", Roles.User);
            usersRepo.Add(user);

            var result = usersRepo.Get(1);

            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void Get_GetNonExistingItem_ShouldReturnNull()
        {
            var result = usersRepo.Get(13);

            Assert.AreEqual(null, result);
        }
    }
}
