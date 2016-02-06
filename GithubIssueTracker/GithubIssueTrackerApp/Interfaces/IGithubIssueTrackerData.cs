namespace GithubIssueTrackerApp.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using Wintellect.PowerCollections;
    
    public interface IGithubIssueTrackerData
    {
        int IssueId { get; set; }

        User LoggedInUser { get; set; }

        IDictionary<string, User> Users { get; }

        OrderedDictionary<int, Issue> Issues { get; }

        MultiDictionary<string, Issue> UserIssues { get; }

        MultiDictionary<string, Issue> TagIssues { get; }

        MultiDictionary<User, Comment> UserComments { get; }

        // int AddIssue(Issue issue);

        // void RemoveIssue(Issue issue);
    }
}