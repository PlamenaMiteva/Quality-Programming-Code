namespace IssueTrackerTests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GithubIssueTrackerApp.Core;
    using GithubIssueTrackerApp.Enums;
    using GithubIssueTrackerApp.Interfaces;
    using GithubIssueTrackerApp.Models;

    [TestClass]
    public class CreateIssueTests
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
        public void CreateIssue_CreateIssueValidData_ShouldCreateAndReturnSuccessMessage()
        {
            this.data.LoggedInUser = new User("admin", "Password123");
            var tags = new List<string> {"tag1"};
            var inputTags = new string[] { "tag1" };
            var issue = new Issue("issue", "issue description", IssuePriority.High, tags);
            var issueId = 1;
           
            var result = this.tracker.CreateIssue("issue", "issue description", IssuePriority.High, inputTags);

            var successMessage = string.Format("Issue {0} created successfully.", issueId);
            
            Assert.AreEqual(successMessage, result);
            Assert.IsTrue(this.data.Issues.ContainsKey(issueId));
            Assert.AreEqual(issue.ToString(), this.data.Issues[1].ToString());
        }

        [TestMethod]
        public void CreateIssue_NotLoggedInUser_ShouldNotRegisterAndReturnErrorMessage()
        {
            var inputTags = new string[] { "tag1" };
            var result = this.tracker.CreateIssue("issue", "issue description", IssuePriority.High, inputTags);

            var errorMessage = "There is no currently logged in user";

            Assert.AreEqual(errorMessage, result);
            Assert.AreEqual(0, this.data.Issues.Count);
        }
    }
}