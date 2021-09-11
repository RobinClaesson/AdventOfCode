using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    class Guard
    {
        public int id;
        public List<DateTime> sleepTimes;

        public Guard(int id)
        {
            this.id = id;
            sleepTimes = new List<DateTime>();
        }

        public int TotalMinutesAsleep
        {
            get
            {
                int min = 0;
                for (int i = 0; i < sleepTimes.Count; i += 2)
                {
                    min += (int)(sleepTimes[i + 1] - sleepTimes[i]).TotalMinutes;
                }


                return min;
            }
        }

        private List<int> MinutesAsleep
        {
            get
            {
                List<int> minutes = new List<int>();

                for (int i = 0; i < sleepTimes.Count; i += 2)
                {
                    DateTime d = sleepTimes[i];

                    while (d.Minute != sleepTimes[i + 1].Minute)
                    {
                        minutes.Add(d.Minute);
                        d = d.AddMinutes(1);
                    }
                }

                return minutes;
            }
        }

        public int MinuteMostAsleep
        {
            get
            {
                List<int> minutes = MinutesAsleep;
                return minutes.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First(); //https://stackoverflow.com/questions/355945/find-the-most-occurring-number-in-a-listint
            }
        }

        public int MinuteMostAsleepTimes
        {
            get
            {
                List<int> minutes = MinutesAsleep;
                var most = minutes.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First(); //https://stackoverflow.com/questions/355945/find-the-most-occurring-number-in-a-listint

                return minutes.Count(x => x.Equals(most));
            }
        }
    }
}
