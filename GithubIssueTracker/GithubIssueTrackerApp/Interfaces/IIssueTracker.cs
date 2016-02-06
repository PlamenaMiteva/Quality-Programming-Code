namespace GithubIssueTrackerApp.Interfaces
{
    using Enums;

    /// <summary>
    /// Contains methods for working with an issue tracker system.
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        /// Registers an user in the database.
        /// </summary>
        /// <param name="username">The username of the user to register.</param>
        /// <param name="password">The password of the user to register.</param>
        /// <param name="confirmPassword">The password confirmation of the user to register. 
        /// In order for the registration to be valid the password and the password confirmation should match.</param>
        /// <returns>Returns success message in case user has been successfully registered and an error message otherwise.</returns>
        string RegisterUser(string username, string password, string confirmPassword);
        
        /// <summary>
        /// Logs an user in the database.
        /// </summary>
        /// <param name="username">The username of the user to log in.</param>
        /// <param name="password">The password of the user to log in.</param>
        /// <returns>Returns success message in case user has been successfully logged in and an error message otherwise.</returns>
        string LoginUser(string username, string password);
        
        /// <summary>
        /// Logs out an user from the database.
        /// </summary>
        /// <returns>Returns success message in case user has been successfully logged out and an error message otherwise.</returns>
        string LogoutUser();
        
        /// <summary>
        /// Creates new issue in the database.
        /// </summary>
        /// <param name="title">The new issue title</param>
        /// <param name="description">The new issue description</param>
        /// <param name="priority">The new issue priority level.</param>
        /// <param name="tags">The new issue tags</param>
        /// <returns>Returns success message in case a new issue has been successfully created.
        /// Only logged in users can create new issues.</returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);
        
        /// <summary>
        /// Removes an issue by a given id from the database.
        /// </summary>
        /// <param name="issueId">The id of the issue</param>
        /// <returns>Returns success message in case a new issue has been successfully removed from the database and 
        /// an error message in case an issue with the given id is not found in the database.
        /// Only logged in users can create new issues.</returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// Adds a comment to an issue
        /// </summary>
        /// <param name="issueId">The id of the issue to which the comment will be added</param>
        /// <param name="commentText">The text of the comment.</param>
        /// <returns>Returns success message in case a new comment has been successfully added to the issue with the given id and 
        /// an error message in case an issue with the given id is not found in the database.
        /// Only logged in users can add comments to issues.</returns>
        string AddComment(int issueId, string commentText);
        

        /// <summary>
        /// Shows all issues of the logged in user.
        /// </summary>
        /// <returns>Returns all issues of the logged in user</returns>
        string GetMyIssues();
        
        /// <summary>
        /// Shows all comments of the logged in user.
        /// </summary>
        /// <returns>Returns all comments of the logged in user</returns>
        string GetMyComments();

        /// <summary>
        /// Searches for issues containing one or more of the provided tags.
        /// </summary>
        /// <param name="tags">Key words to be serched for.</param>
        /// <returns>Returns a list of matching issues.</returns>
        string SearchForIssues(string[] tags);
        }
}
