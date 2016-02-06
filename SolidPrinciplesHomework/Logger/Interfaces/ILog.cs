using System;
using Logger.Models;

namespace Logger.Interfaces
{
    public interface ILog
    {
        DateTime LogDate { get;}

        Level Level { get; }

        string Message { get;}
    }
}
