using System.Collections.Generic;
using Logger.Models;

namespace Logger.Interfaces
{
    public interface ILogger
    {
        IList<IAppender> Appenders { get;}

        void AppendLog(Log log);
    }
}
