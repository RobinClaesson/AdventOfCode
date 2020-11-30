using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_14
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> input = IO.InputRows;


            List<Reindeer> reindeers = new List<Reindeer>();
            foreach (string row in input)
            {
                reindeers.Add(new Reindeer(int.Parse(row.Split(' ')[3]), int.Parse(row.Split(' ')[6]), int.Parse(row.Split(' ')[13])));
            }

            int raceLength = 2503;

            Part1(reindeers, raceLength);

            //Part 2
            Console.WriteLine("Part 2");
            foreach (Reindeer reindeer in reindeers)
                reindeer.Reset();

            for (int i = 0; i < raceLength; i++)
            {
                foreach (Reindeer reindeer in reindeers)
                    reindeer.Update();

                int maxDistance = int.MinValue;

                foreach (Reindeer reindeer in reindeers)
                    if (reindeer.DistanceTravled > maxDistance)
                        maxDistance = reindeer.DistanceTravled;


                foreach (Reindeer reindeer in reindeers)
                    if (reindeer.DistanceTravled == maxDistance)
                        reindeer.AwardPoint();

            }

            int maxPoints = int.MinValue;

            foreach (Reindeer reindeer in reindeers)
                if (reindeer.Points > maxPoints)
                    maxPoints = reindeer.Points;

            IO.Output(maxPoints);

            Console.ReadKey();
        }

        private static void Part1(List<Reindeer> reindeers, int raceLength)
        {
            Console.WriteLine("Part 1");
            for (int i = 0; i < raceLength; i++)
                foreach (Reindeer reindeer in reindeers)
                    reindeer.Update();

            int maxDistance = int.MinValue;

            foreach (Reindeer reindeer in reindeers)
                if (reindeer.DistanceTravled > maxDistance)
                    maxDistance = reindeer.DistanceTravled;

            IO.Output(maxDistance);
        }
    }
}
