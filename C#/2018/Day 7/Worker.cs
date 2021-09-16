using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Worker
    {
        int tick = 0;
        int baseTime;
        string workingOn = ".";

        public Worker(int baseTime)
        {
            this.baseTime = baseTime;
        }

        public void StartWork(string workOn)
        {
            workingOn = workOn;
            tick = baseTime + (int)(workOn[0] - 'A') + 1;
        }

        public void Work()
        {
            if (tick > 0)
                tick--;
        }

        public void Reset()
        {
            tick = 0;
            workingOn = ".";
        }

        public bool IsDone
        {
            get
            {
                return tick == 0;
            }
        }

        public string WorkingOn { get { return workingOn; } }

    }
}
