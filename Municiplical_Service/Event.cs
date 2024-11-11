using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municiplical_Service
{
    public class Event
    {
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public string Category { get; set; }

        public Event(string name, DateTime date, string category)
        {
            Name = name;
            EventDate = date;
            Category = category;
        }
    }
}
