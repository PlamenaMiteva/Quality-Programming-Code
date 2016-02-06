namespace IssueTrackerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GithubIssueTrackerApp.Core;
    using GithubIssueTrackerApp.Interfaces;
    using GithubIssueTrackerApp.Models;

    [TestClass]
    public class RegisterUserTests
    {
        private IGithubIssueTrackerData data;
        private IIssueTracker tracker;

        [TestInitialize]
        public void TestInit()
        {
            this.data = new GithubIssueTrackerData();
            this.tracker = new IssueTracker(this.data);
        }

        [TestMethod]
        public void RegisterUser_RegisterNewUser_ShouldRegisterAndReturnSuccessMessage()
        {
            var password = "Password123";
            var user = new User("admin", password);

            var result = this.tracker.RegisterUser(user.Username, password, password);

            var successMessage = string.Format("User {0} registered successfully", user.Username);

            Assert.AreEqual(successMessage, result);
            Assert.AreEqual(1, this.data.Users.Count);
        }

        [TestMethod]
        public void RegisterUser_RegisterExistingUser_ShouldNotRegisterAndReturnErrorMessage()
        {
            var username = "admin";
            var password = "Password123";
            var user = new User(username, password);
            this.data.Users.Add(username, user);

            var result = this.tracker.RegisterUser(username, password, password);

            var expectedMessage = string.Format("A user with username {0} already exists", username);

            Assert.AreEqual(expectedMessage, result);
            Assert.AreEqual(1, this.data.Users.Count);
        }

        [TestMethod]
        public void RegisterUser_RegisterNewUserWithIncorrectConfirmPassword_ShouldnotRegisterAndReturnErrorMessage()
        {
            var password = "Password123";
            var user = new User("admin", password);

            var result = this.tracker.RegisterUser(user.Username, password, "NewPassword123");

            var expectedMessage = "The provided passwords do not match";

            Assert.AreEqual(expectedMessage, result);
            Assert.AreEqual(0, this.data.Users.Count);
        }

        [TestMethod]
        public void RegisterUser_RegisterLoggedInUser_ShouldNotRegisterAndReturnErrorMessage()
        {
            var username = "admin";
            var password = "Password123";
            var user = new User(username, password);
            this.data.Users.Add(username, user);
            this.data.LoggedInUser = user;

            var result = this.tracker.RegisterUser(username, password, password);

            var expectedMessage = "There is already a logged in user";

            Assert.AreEqual(expectedMessage, result);
            Assert.AreEqual(1, this.data.Users.Count);
        }
    }
}
