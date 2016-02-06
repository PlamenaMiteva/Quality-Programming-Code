namespace GithubIssueTrackerApp.Core
{
    using Enums;
    using Interfaces;

    public class Dispatcher
    {
        public Dispatcher(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public Dispatcher() :
            this(new IssueTracker())
        {
        }

        public IIssueTracker Tracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            // BUG case Logout missing
            // BUG AddComment param should be "id"
            // BUG tags should be splitted by '|'
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return this.Tracker.RegisterUser(endpoint.Params["username"], endpoint.Params["password"], endpoint.Params["confirmPassword"]);
                case "LoginUser":
                    return this.Tracker.LoginUser(endpoint.Params["username"], endpoint.Params["password"]);
                case "LogoutUser":
                    return this.Tracker.LogoutUser();
                case "CreateIssue":
                    return this.Tracker.CreateIssue(
                        endpoint.Params["title"], 
                        endpoint.Params["description"],
                        (IssuePriority)System.Enum.Parse(typeof(IssuePriority), endpoint.Params["priority"], true),
                        endpoint.Params["tags"].Split('|'));
                case "RemoveIssue":
                    return this.Tracker.RemoveIssue(int.Parse(endpoint.Params["id"]));
                case "AddComment":
                    return this.Tracker.AddComment(
                        int.Parse(endpoint.Params["id"]),
                        endpoint.Params["text"]);
                case "MyIssues": return this.Tracker.GetMyIssues();
                case "MyComments": return this.Tracker.GetMyComments();
                case "Search":
                    return this.Tracker.SearchForIssues(endpoint.Params["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.ActionName);
            }
        }
    }
}
