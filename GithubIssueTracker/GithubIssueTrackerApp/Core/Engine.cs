namespace GithubIssueTrackerApp.Core
{
    using System;
    using Interfaces;

    public class Engine : IEngine
    {
        private Dispatcher dispatcher;
        private IUserInterface userInterface;
        
        public Engine(Dispatcher dispatcher, IUserInterface userInterface)
        {
            this.dispatcher = dispatcher;
            this.userInterface = userInterface;
        }

        public Engine()
            : this(new Dispatcher(), new ConsoleInterface())
        {
        }

        public void Run()
        {
            while (true)
            {
                string url = userInterface.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endpoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endpoint);
                        userInterface.WriteLine(viewResult);
                    }
                    catch (System.Exception ex)
                    {
                        userInterface.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
