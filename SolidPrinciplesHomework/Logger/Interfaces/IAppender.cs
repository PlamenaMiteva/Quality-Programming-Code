using Logger.Models;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        void ExecuteAppendLog(Log log);
    }
}
