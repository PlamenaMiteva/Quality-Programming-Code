namespace Logger.Interfaces
{
    using Logger.Models;

    public interface ILayout
    {
        string Format(Log log);
    }
}
