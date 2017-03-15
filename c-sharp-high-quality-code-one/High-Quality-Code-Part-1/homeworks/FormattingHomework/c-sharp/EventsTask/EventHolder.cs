using System;
using System.Text;
using Wintellect.PowerCollections;

namespace EventsTask
{
    class EventHolder
    {
        MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        OrderedBag<Event> byDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location, StringBuilder output)
        {
            Event newEvent = new Event(date, title, location);
            byTitle.Add(title.ToLower(), newEvent);
            byDate.Add(newEvent);
            Messages.EventAdded(output);
        }

        public void DeleteEvents(string titleToDelete, StringBuilder output)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in byTitle[title])
            {
                removed++;
                byDate.Remove(eventToRemove);
            }
            byTitle.Remove(title);
            Messages.EventDeleted(removed, output);
        }

        public void ListEvents(DateTime date, int count, StringBuilder output)
        {
            OrderedBag<Event>.View eventsToShow = byDate.RangeFrom(new Event(date, "", ""), true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow, output);

                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound(output);
            }
        }
    }
}
