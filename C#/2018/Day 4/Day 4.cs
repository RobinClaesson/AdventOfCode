using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            //Create events
            List<Event> events = new List<Event>();
            foreach (string row in input)
            {
                string[] date = row.Split(' ')[0].Split('-');

                int month = int.Parse(date[1]);
                int day = int.Parse(date[2]);

                string[] time = row.Split(' ')[1].Split(':');

                int hour = int.Parse(time[0]);
                int minute = int.Parse(time[1].Substring(0, 2));


                events.Add(new Event(new DateTime(2000, month, day, hour, minute, 0), row.Substring(19)));
            }

            //Sort events by date
            events = events.OrderBy(e => e.dt).ToList(); //Learning to love Linq <3 

            //Create guards from events
            List<Guard> guards = new List<Guard>();
            int i = 0;
            while (i < events.Count)
            {
                int id = int.Parse(events[i].info.Split(' ')[1].Substring(1));
                i++;

                while (i < events.Count && !events[i].info.Contains('#'))
                {
                    bool found = false;

                    foreach (Guard g in guards)
                        if (g.id == id)
                        {
                            found = true;
                            g.sleepTimes.Add(events[i].dt);
                            break;
                        }

                    if (!found)
                    {
                        Guard g = new Guard(id);
                        g.sleepTimes.Add(events[i].dt);
                        guards.Add(g);
                    }
                    i++;
                }
            }

            //Part 1
            guards = guards.OrderBy(g => g.TotalMinutesAsleep).ToList(); 

            int guardId = guards.Last().id;
            int min = guards.Last().MinuteMostAsleep;
            IO.Output(guardId * min);

            //Part 2
            guards = guards.OrderBy(g => g.MinuteMostAsleepTimes).ToList(); 

            guardId = guards.Last().id;
            min = guards.Last().MinuteMostAsleep;

            IO.Output(guardId * min);

            Console.ReadKey();
        }
    }
}
