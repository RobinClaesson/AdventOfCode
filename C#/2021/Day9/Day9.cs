using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    class Day9
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            List<int> lowPoints = new List<int>();
            for (int y = 0; y < input.Count; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {

                    //Upp
                    if (y > 0 && input[y - 1][x] <= input[y][x])
                        continue;
                    //Left
                    if (x > 0 && input[y][x - 1] <= input[y][x])
                        continue;
                    //Down
                    if (y < input.Count - 1 && input[y + 1][x] <= input[y][x])
                        continue;
                    //Right
                    if (x < input[y].Length - 1 && input[y][x + 1] <= input[y][x])
                        continue;

                    lowPoints.Add(x);
                    lowPoints.Add(y);
                }
            }

            int part1 = 0;
            for (int i = 0; i < lowPoints.Count; i += 2)
            {
                part1 += 1 + int.Parse(input[lowPoints[i + 1]][lowPoints[i]] + "");
            }
            IO.Output(part1);


            //Part2
            List<List<char>> basins = new List<List<char>>();
            for (int i = 0; i < lowPoints.Count; i += 2)
            {
                basins.Add(Basin(input, lowPoints[i], lowPoints[i + 1], new List<string>()));
            }

            basins = basins.OrderByDescending(b => b.Count).ToList();

            IO.Output(basins[0].Count * basins[1].Count * basins[2].Count);
            Console.ReadKey();
        }

        public static List<char> Basin(List<string> map, int x, int y, List<string> visited)
        {
            List<char> basin = new List<char>();

            basin.Add(map[y][x]);
            visited.Add($"{x},{y}");

            //Upp
            if (y > 0 && map[y - 1][x] != '9' && map[y - 1][x] > map[y][x] && !visited.Contains($"{x},{y - 1}"))
                basin.AddRange(Basin(map, x, y - 1, visited));

            //Down
            if (y < map.Count - 1 && map[y + 1][x] != '9' && map[y + 1][x] > map[y][x] && !visited.Contains($"{x},{y + 1}"))
                basin.AddRange(Basin(map, x, y + 1, visited));

            //Left
            if (x > 0 && map[y][x - 1] != '9' && map[y][x - 1] > map[y][x] && !visited.Contains($"{x - 1},{y}"))
                basin.AddRange(Basin(map, x - 1, y, visited));

            //Right
            if (x < map[y].Length - 1 && map[y][x + 1] != '9' && map[y][x + 1] > map[y][x] && !visited.Contains($"{x + 1 },{y}"))
                basin.AddRange(Basin(map, x + 1, y, visited));

            return basin;
        }
    }
}
