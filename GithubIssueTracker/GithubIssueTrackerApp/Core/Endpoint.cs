namespace GithubIssueTrackerApp.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string actionName)
        {
            int questionMarkIndex = actionName.IndexOf('?');
            if (questionMarkIndex != -1)
            {
                this.ActionName = actionName.Substring(0, questionMarkIndex);
                var @params = actionName.Substring(questionMarkIndex + 1).Split('&')
                              .Select(x => x.Split('=')
                              .Select(xx => WebUtility.UrlDecode(xx))
                              .ToArray());
                var parameters = @params.ToDictionary(param => param[0], param => param[1]);
                this.Params = parameters;
            }
            else
            {
                this.ActionName = actionName;
            }
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Params { get; set; }
    }
}
