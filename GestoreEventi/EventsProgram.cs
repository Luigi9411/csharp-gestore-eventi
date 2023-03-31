using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class EventsProgram
    {
        private string title;
        private List<Event> events = new();

        public EventsProgram(string title)
        {
            this.title = title;
        }

        public void AddEvent(Event @event)
        {
            events.Add(@event);
        }

        public List<Event> EventsInDate(DateTime date)
        {
            var res = new List<Event>();

            foreach (Event @event in events)
            {
                if (@event.Date == date)
                {
                    res.Add(@event);
                }
            }

            return res;
        }

        public  string PrintEvents(List<Event> events)
        {
            var line = Environment.NewLine;
            string res = string.Empty;

            foreach (Event @event in events)
            {
                res += @event.ToString() + line;
            }

            return res;
        }

        public int NumberEvents()
        {
            return events.Count;
        }

        public void ClearEvents()
        {
            events.Clear();
        }

        public override string ToString()
        {
            var line = Environment.NewLine;
            return title + line + PrintEvents(events);
        }
    }
}


