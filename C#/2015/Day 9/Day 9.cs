using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> input = IO.InputRows;

            //Adds the cities
            List<string> cities = new List<string>();
            foreach (string row in input)
            {
                string city1 = row.Split(' ')[0];
                string city2 = row.Split(' ')[2];

                if (!cities.Contains(city1))
                    cities.Add(city1);
                if (!cities.Contains(city2))
                    cities.Add(city2);
            }

            int shortestDistance = int.MaxValue, longestDistance = int.MinValue;
            int testedRoutes = 0;

            int maxloop = (int)Math.Pow(10, cities.Count);
            //Calculates all possible routes and finds shortest distance
            for (int i = 0; i < maxloop; i++)
            {
                string route = "" + i;

                while (route.Length < cities.Count)
                    route = "0" + route;

                bool toLarge = false;
                foreach (char c in route)
                    if (int.Parse("" + c) >= cities.Count)
                        toLarge = true;

                //This is a route that visit all cities exactly one time
                if (route.Distinct().Count() == route.Count() && !toLarge)
                {
                    int distance = 0;
                    for (int j = 1; j < route.Count(); j++)
                    {
                        string start = cities[int.Parse(route[j - 1] + "")];
                        string end = cities[int.Parse(route[j] + "")];

                        foreach (string row in input)
                        {
                            string city1 = row.Split(' ')[0];
                            string city2 = row.Split(' ')[2];

                            if ((city1 == start && city2 == end) || (city2 == start && city1 == end))
                            {
                                distance += int.Parse(row.Split(' ')[4]);
                            }
                        }


                    }
                    if (distance < shortestDistance)
                        shortestDistance = distance;

                    else if (distance > longestDistance)
                        longestDistance = distance;


                }
                testedRoutes++;

                if (testedRoutes % 100000 == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Calculating Routes");
                    Console.WriteLine("Tested Routes: " + testedRoutes + "/" + maxloop);
                }
            }

            IO.Output(shortestDistance);
            IO.Output(longestDistance, true);

            Console.ReadKey();
        }
    }
}
