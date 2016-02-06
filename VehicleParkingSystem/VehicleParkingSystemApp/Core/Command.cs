namespace VehicleParkingSystemApp.Core
{
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using Interfaces;
   
    public class Command : ISystemCommand
    {
        public Command(string commandLine)
        {
            this.ParseCommand(commandLine);
        }

        public string Name { get; private set; }

        public IDictionary<string, string> Params { get; private set; }

        private void ParseCommand(string commandLine)
        {
            int commandNameEnd = commandLine.IndexOf(' ');
            string commandName = commandLine.Substring(0, commandNameEnd);
            string commandParametersAsString = commandLine.Substring(commandNameEnd + 1);
            var commandParameters = this.ParseCommandParameters(commandParametersAsString);
            this.Name = commandName;
            this.Params = commandParameters;
        }

        private IDictionary<string, string> ParseCommandParameters(string commandParametersAsString)
        {
            var serializer = new JavaScriptSerializer();
            var parameters = serializer.Deserialize<Dictionary<string, string>>(commandParametersAsString);
            return parameters;
        }
    }
}