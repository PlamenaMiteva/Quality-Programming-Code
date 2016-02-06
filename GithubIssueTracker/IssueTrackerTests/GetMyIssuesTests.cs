namespace IssueTrackerTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GithubIssueTrackerApp.Core;
    using GithubIssueTrackerApp.Enums;
    using GithubIssueTrackerApp.Interfaces;
    using GithubIssueTrackerApp.Models;

    [TestClass]
    public class GetMyIssuesTests
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
        public void GetMyIssues_LoggedInUser_ShouldReturnUsersIssues()
        {
            this.data.LoggedInUser = new User("admin", "Password123");
            var inputTags = new string[] { "tag1" };
            var issue1 = new Issue("issue 1", "issue description 1", IssuePriority.High, inputTags.ToList());
            var issue2 = new Issue("issue 2", "issue description 2", IssuePriority.Medium, inputTags.ToList());
            StringBuilder userIssues = new StringBuilder();
            userIssues.AppendLine(issue1.ToString());
            userIssues.AppendLine(issue2.ToString());

            this.tracker.CreateIssue("issue 1", "issue description 1", IssuePriority.High, inputTags);
            this.tracker.CreateIssue("issue 2", "issue description 2", IssuePriority.Medium, inputTags);
            var result = this.tracker.GetMyIssues();

            Assert.AreEqual(userIssues.ToString().Trim(), result);
        }

        [TestMethod]
        public void GetMyIssues_LoggedInUserWithoutIssues_ShouldReturnNoIssuesMessage()
        {
            this.data.LoggedInUser = new User("admin", "Password123");

            var result = this.tracker.GetMyIssues();

            var expectedMessage = "No issues";

            Assert.AreEqual(expectedMessage, result);
        }

        [TestMethod]
        public void GetMyIssues_NotLoggedInUser_ShouldReturnErrorMessage()
        {
            var result = this.tracker.GetMyIssues();

            var errorMessage = "There is no currently logged in user";

            Assert.AreEqual(errorMessage, result);
        }
    }
}