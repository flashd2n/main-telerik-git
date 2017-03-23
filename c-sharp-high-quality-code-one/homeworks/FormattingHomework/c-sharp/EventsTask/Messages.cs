using System;
using System.Text;
using Wintellect.PowerCollections;

namespace EventsTask
{
    static class Messages
    {
        public static void EventAdded(StringBuilder output)
        {
            output.Append("Event added\n");
        }

        public static void EventDeleted(int x, StringBuilder output)
        {
            if (x == 0)
            {
                NoEventsFound(output);
            }

            else
            {
                output.AppendFormat("{0} events deleted\n", x);
            }

        }

        public static void NoEventsFound(StringBuilder output)
        {
            output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint, StringBuilder output)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }
}
