namespace IssueTrackerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GithubIssueTrackerApp.Core;
    using GithubIssueTrackerApp.Enums;
    using GithubIssueTrackerApp.Interfaces;
    using GithubIssueTrackerApp.Models;

    [TestClass]
    public class SearchIssuesTests
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
        public void SearchIssues_ValidTag_ShouldReturnIssues()
        {
            this.data.LoggedInUser = new User("admin", "Password123");
            var inputTags = new string[] {"issue"};
            var issue3Tags = new string[] { "problem" };
            var issue1 = new Issue("issue 1", "issue description 1", IssuePriority.High, inputTags.ToList());
            var issue2 = new Issue("issue 2", "issue description 2", IssuePriority.Medium, inputTags.ToList());
            var issue3 = new Issue("problem", "problem description", IssuePriority.Low, issue3Tags.ToList());
            
            this.tracker.CreateIssue("issue 1", "issue description 1", IssuePriority.High, inputTags);
            this.tracker.CreateIssue("issue 2", "issue description 2", IssuePriority.Medium, inputTags);
            this.tracker.CreateIssue("problem", "problem description", IssuePriority.Low, issue3Tags);
            var issues = this.data.TagIssues["issue"]
                         .Distinct()
                         .OrderByDescending(x => x.Priority)
                         .ThenBy(x => x.Title);
            var expected = string.Join(Environment.NewLine, issues);

            var result = this.tracker.SearchForIssues(inputTags);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SearchIssues_InvalidTag_ShouldNotReturnIssues()
        {
            var inputTags = new string[] { "issue" };
            var result = this.tracker.SearchForIssues(inputTags);

            var expectedMessage = "There are no issues matching the tags provided";

            Assert.AreEqual(expectedMessage, result);
        }

        [TestMethod]
        public void SearchIssues_WithoutInputTag_ShouldReturnerrorMessage()
        {
            var inputTags = new string[]{};
            var result = this.tracker.SearchForIssues(inputTags);

            var expectedMessage = "There are no tags provided";

            Assert.AreEqual(expectedMessage, result);
        }
    }
}