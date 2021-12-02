using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day2
{
    class Day2
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted(' ');

            int x = 0, y = 0, aim = 0, y2 = 0;

            foreach (string[] move in input)
            {
                int steps = int.Parse(move[1]);

                if (move[0] == "down")
                {
                    y += steps;
                    aim += steps;
                }
                else if (move[0] == "up")
                {
                    y -= steps;
                    aim -= steps;
                }
                else if (move[0] == "forward")
                {
                    x += steps;
                    y2 += aim * steps;
                }
            }


            IO.Output(x * y);
            IO.Output(x * y2);
            Console.ReadKey();
        }
    }
}
