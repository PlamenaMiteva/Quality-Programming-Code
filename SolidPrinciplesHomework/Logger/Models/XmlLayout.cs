using System.Text;
using Logger.Interfaces;

namespace Logger.Models
{
    public class XmlLayout : ILayout
    {
        public string Format(Log log)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<log>");
            builder.AppendLine(string.Format("<date>{0}</date>", log.LogDate));
            builder.AppendLine(string.Format("<level>{0}</level>", log.Level.Name));
            builder.AppendLine(string.Format("<message>{0}</message>", log.Message));
            builder.AppendLine("</log>");

            return builder.ToString();
        }
    }
}
