using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Wire
    {
        public string id;
        public int signal;

        public Wire(string id)
        {
            this.id = id;
            this.signal = int.MinValue;
        }

        public override string ToString()
        {
            return id + ": " + signal;
        }
    }
}
