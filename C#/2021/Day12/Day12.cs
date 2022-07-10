using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day12
{
    class Day12
    {
        static List<string> paths = new List<string>();
        static Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            var input = IO.InputRows;

            foreach (var row in input)
            {
                var caves = row.Replace(" ", "").Split('-');

                if (!connections.ContainsKey(caves[0]))
                    connections.Add(caves[0], new List<string>());
                if (!connections.ContainsKey(caves[1]))
                    connections.Add(caves[1], new List<string>());

                if (caves[1] != "start")
                    connections[caves[0]].Add(caves[1]);
                if (caves[0] != "start")
                    connections[caves[1]].Add(caves[0]);
            }

            Part1("start");
            IO.Output(paths.Count);

            paths.Clear();
            Part2("start");
            IO.Output(paths.Count);


            Console.ReadKey();
        }

        private static void Part1(string path)
        {
            var splitPath = path.Split(',');

            foreach (var connection in connections[splitPath.Last()])
            {
                if (connection == "end")
                {
                    paths.Add($"{path},{connection}");
                }
                else if (connection[0] < 'a' || !splitPath.Contains(connection))
                {
                    Part1($"{path},{connection}");
                }
            }
        }

        private static void Part2(string path)
        {
            var splitPath = path.Split(',');

            foreach (var connection in connections[splitPath.Last()])
            {
                if (connection == "end")
                {
                    paths.Add($"{path},{connection}");
                }
                else if (connection[0] < 'a' || !splitPath.Contains(connection))
                {
                    Part2($"{path},{connection}");
                }
                else
                {
                    var smallCavesVisitedTwice = splitPath.Where(x => x[0] >= 'a').GroupBy(x => x).Where(x => x.Count() > 1).Count();

                    if (smallCavesVisitedTwice == 0)
                    {
                        Part2($"{path},{connection}");
                    }
                }
            }
        }
    }
}
