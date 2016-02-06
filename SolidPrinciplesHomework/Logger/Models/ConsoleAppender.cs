using System;
using Logger.Interfaces;

namespace Logger.Models
{
    public class ConsoleAppender: IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public void ExecuteAppendLog(Log log)
        {
            Console.WriteLine(layout.Format(log));
        }
    }
}
