using System;
using System.Collections.Generic;
using Logger.Interfaces;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        private IList<IAppender> appenders;

        public Logger(IList<IAppender> appenders)
        {
            this.Appenders = appenders;
        }

        public IList<IAppender> Appenders
        {
            get { return this.appenders; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Appenders cannot be null.");
                }
                if (value.Count == 0)
                {
                    throw new ArgumentException("Appenders cannot be empty.");
                }

                this.appenders = value;
            }
        }

        public void AppendLog(Log log)
        {
            foreach (var appender in this.Appenders)
            {
                appender.ExecuteAppendLog(log);
            }
        }
    }
}
