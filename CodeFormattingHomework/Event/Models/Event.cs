namespace Event.Models
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, String title, String location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int compareByDate = this.date.CompareTo(other.date);
            int compareByTitle = this.title.CompareTo(other.title);
            int byLocation = this.location.CompareTo(other.location);

            if (compareByDate == 0)
            {
                return compareByTitle == 0 ? byLocation : compareByTitle;
            }
                return compareByDate;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.Append(date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + title);

            if (location != null && location != "")
            {
                toString.Append(" | " + location);
            }

            return toString.ToString();

        }
    }
}
