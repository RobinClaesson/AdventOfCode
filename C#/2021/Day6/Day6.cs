using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Day6
    {
        static void Main(string[] args)
        {
            List<int> fishes = IO.InputSplitted_Int(',');

            long[] days = new long[7];
            long[] newSpawn = new long[7];
            int currentDay = 0;

            //Adds init state 
            for (int i = 0; i < 7; i++)
                days[i] = fishes.Count(f => f == i);

            for (int i = 0; i < 80; i++)
            {
                int spawnsAt = (currentDay + 2 + days.Length) % days.Length;
                newSpawn[spawnsAt] = days[currentDay];

                days[currentDay] += newSpawn[currentDay];
                newSpawn[currentDay] = 0;

                currentDay = (1 + currentDay + days.Length) % days.Length;
            }

            IO.Output(days.Sum() + newSpawn.Sum());

            //Part 2 
            for (int i = 0; i < 176; i++)
            {
                int spawnsAt = (currentDay + 2 + days.Length) % days.Length;
                newSpawn[spawnsAt] = days[currentDay];

                days[currentDay] += newSpawn[currentDay];
                newSpawn[currentDay] = 0;

                currentDay = (1 + currentDay + days.Length) % days.Length;
            }
            long p2 = days.Sum();
            p2 += newSpawn.Sum();

            IO.Output(p2);
            Console.ReadKey();
        }
    }
}
