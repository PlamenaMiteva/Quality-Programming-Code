using System.Text;
using Logger.Interfaces;

namespace Logger.Models
{
    class SimpleLayout : ILayout
    {
        public string Format(Log log)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(log.LogDate);
            builder.Append(" - ");
            builder.Append(log.Level.Name);
            builder.Append(" - ");
            builder.Append(log.Message);

            return builder.ToString();
        }
    }
}
