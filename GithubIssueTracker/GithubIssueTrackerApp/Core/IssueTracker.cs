namespace GithubIssueTrackerApp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;
    using Interfaces;
    using Models;
    
    public class IssueTracker : IIssueTracker
    {
        private const string NoLoggedInUserMessage = "There is no currently logged in user";

        public IssueTracker(IGithubIssueTrackerData data)
        {
            this.Data = data as GithubIssueTrackerData;
        }

        public IssueTracker()
            : this(new GithubIssueTrackerData())
        {
        }

        public IGithubIssueTrackerData Data { get; private set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            // BUG FIXED Data.LoggedInUser should not be null if there is a currently logged in user.
            if (this.Data.LoggedInUser != null)
            {
                return "There is already a logged in user";
            }

            if (password != confirmPassword)
            {
                return "The provided passwords do not match";
            }

            if (this.Data.Users.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.Data.Users.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            // BUG Data.LoggedInUser should not be null if there is a currently logged in user.
            if (this.Data.LoggedInUser != null)
            {
                return "There is already a logged in user";
            }

            if (!this.Data.Users.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Data.Users[username];
            if (user.Password != Utilities.HashUtilities.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.Data.LoggedInUser = user;
            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.Data.LoggedInUser == null)
            {
                return NoLoggedInUserMessage;
            }

            string username = this.Data.LoggedInUser.Username;
            this.Data.LoggedInUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            if (this.Data.LoggedInUser == null)
            {
                return NoLoggedInUserMessage;
            }

            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            issue.Id = this.Data.IssueId;
            this.Data.Issues.Add(issue.Id, issue);
            this.Data.IssueId++;
            this.Data.UserIssues[this.Data.LoggedInUser.Username].Add(issue);

            foreach (var tag in issue.Tags)
            {
                this.Data.TagIssues[tag].Add(issue);
            }

            return string.Format("Issue {0} created successfully.", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.LoggedInUser == null)
            {
                return NoLoggedInUserMessage;
            }

            if (!this.Data.Issues.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.Issues[issueId];
            if (!this.Data.UserIssues[this.Data.LoggedInUser.Username].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}", 
                    issueId, 
                    this.Data.LoggedInUser.Username);
            }

            this.Data.UserIssues[this.Data.LoggedInUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.Data.TagIssues[tag].Remove(issue);
                this.Data.Issues.Remove(issue.Id);
            }

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int issueId, string commentText)
        {
            if (this.Data.LoggedInUser == null)
            {
                return NoLoggedInUserMessage;
            }

            if (!this.Data.Issues.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId + 1);
            }

            var issue = this.Data.Issues[issueId];
            var comment = new Comment(this.Data.LoggedInUser, commentText);
            issue.AddComment(comment);
            this.Data.UserComments[this.Data.LoggedInUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.Data.LoggedInUser == null)
            {
                return NoLoggedInUserMessage;
            }

            var issues = this.Data.UserIssues[this.Data.LoggedInUser.Username];
            if (!issues.Any())
            {
                return "No issues";
            }

            StringBuilder result = new StringBuilder();
            foreach (var issue in issues)
            {
                result.AppendLine(issue.ToString());
            }

            return result.ToString().Trim();
        }

        public string GetMyComments()
        {
            if (this.Data.LoggedInUser == null)
            {
                return NoLoggedInUserMessage;
            }
            
            var comments = this.Data.UserComments[this.Data.LoggedInUser];
            if (!comments.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, comments);
        }

        public string SearchForIssues(string[] tags)
        {
            // BUG FIXED tags array is empty if lenght is zero.
            if (tags.Length <= 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.Data.TagIssues[tag]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var orderedIssues = issues.Distinct()
                         .OrderByDescending(x => x.Priority)
                         .ThenBy(x => x.Title);

            return string.Join(Environment.NewLine, orderedIssues);
        }
    }
}
