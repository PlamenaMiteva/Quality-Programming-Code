namespace GithubIssueTrackerApp.Models
{
    using Utilities;

    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = HashUtilities.HashPassword(password);
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
