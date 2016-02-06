namespace VehicleParkingSystemApp.Core
{
    using System;
    using Interfaces;

    public class Engine : IEngine
    {
        private readonly CommandExecutor executor;
        private readonly IUserInterface userInterface;

        public Engine(CommandExecutor executor, IUserInterface userInterface)
        {
            this.executor = executor;
            this.userInterface = userInterface;
        }

        public Engine()
            : this(new CommandExecutor(), new ConsoleUserInterface())
        {
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.userInterface.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine.Trim();

                // BUG FIXED command string should not be null or empty
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        string commandResult = this.executor.ExecuteCommand(command);
                        this.userInterface.WriteLine(commandResult);
                    }
                    catch (Exception ex)
                    {
                        this.userInterface.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}