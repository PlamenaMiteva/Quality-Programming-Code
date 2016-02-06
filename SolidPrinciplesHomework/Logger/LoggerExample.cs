using System.Collections.Generic;
using Logger.Interfaces;
using Logger.Models;

namespace Logger
{
    class LoggerExample
    {
        static void Main()
        {
            var simpleLayout = new SimpleLayout();

            var consoleAppender = new ConsoleAppender(simpleLayout);
            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.LogFile = "log.txt";

            var errorLog = new Log(new Level("Error"), "Error parsing JSON.");
            var infoLog = new Log(new Level("Info"), string.Format("User {0} successfully registered.", "Pesho"));
            var warnLog = new Log(new Level("Warning"), "Warning - missing files.");

            var logger = new Models.Logger(new List<IAppender> { consoleAppender, fileAppender });
            logger.AppendLog(errorLog);
            logger.AppendLog(infoLog);
            logger.AppendLog(warnLog);

            //xml Logger
            var xmlLayout = new XmlLayout();
            var consoleXmlAppender = new ConsoleAppender(xmlLayout);
            var xmlLogger = new Models.Logger(new List<IAppender>{consoleXmlAppender});

            var fatalLog = new Log(new Level("Fatal"), "mscorlib.dll does not respond");
            var criticalLog = new Log(new Level("Critical"), "No connection string found in App.config");

            xmlLogger.AppendLog(fatalLog);
            xmlLogger.AppendLog(criticalLog);

        }
    }
}
