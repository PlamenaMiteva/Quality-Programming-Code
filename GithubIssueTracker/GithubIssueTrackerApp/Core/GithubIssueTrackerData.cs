namespace GithubIssueTrackerApp.Core
{
    using System.Collections.Generic;
    using GithubIssueTrackerApp.Interfaces;
    using GithubIssueTrackerApp.Models;
    using Wintellect.PowerCollections;

    public class GithubIssueTrackerData : IGithubIssueTrackerData
    {
        private const int InitalIssueId = 1;

        public GithubIssueTrackerData()
        {
            this.IssueId = InitalIssueId;
            this.Users = new Dictionary<string, User>();
            this.Issues = new OrderedDictionary<int, Issue>();
            this.UserIssues = new MultiDictionary<string, Issue>(true);
            this.TagIssues = new MultiDictionary<string, Issue>(true);
            this.UserComments = new MultiDictionary<User, Comment>(true);
        }

        public User LoggedInUser { get; set; }

        public int IssueId { get; set; }

        public IDictionary<string, User> Users { get; private set; }

        public OrderedDictionary<int, Issue> Issues { get; private set; }

        public MultiDictionary<string, Issue> UserIssues { get; private set; }

        public MultiDictionary<string, Issue> TagIssues { get; private set; }

        public MultiDictionary<User, Comment> UserComments { get; private set; }

        // public int AddIssue(Issue issue)
        // {
        //    return 0;
        // }

        // public void RemoveIssue(Issue issue)
        // {
        //    return;
        // }
    }
}
