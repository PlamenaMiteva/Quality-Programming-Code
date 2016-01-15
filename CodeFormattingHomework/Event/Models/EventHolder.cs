namespace Event.Models
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string,Event>(true);
        OrderedBag<Event> evetsByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            eventsByTitle.Add(title.ToLower(), newEvent);
            evetsByDate.Add(newEvent); Message.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in eventsByTitle[title])
            {
                removed++;
                evetsByDate.Remove(eventToRemove);
            }

            eventsByTitle.Remove(title);
            Message.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = evetsByDate.RangeFrom(new Event(date, "", ""),true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Message.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
               Message.NoEventsFound();
            }
        }
    }
}
