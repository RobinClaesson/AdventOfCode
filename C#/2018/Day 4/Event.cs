using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    class Event
    {
        public DateTime dt;
        public string info;

        public Event(DateTime dt, string info)
        {
            this.dt = dt;
            this.info = info;
        }
    }
}
