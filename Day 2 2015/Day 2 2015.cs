using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_2_2015
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1:");

            List<string> input = IO.InputRows;

            int paper = 0;

            foreach (string row in input)
            {
                string[] meassurements = row.Split('x');

                int l = int.Parse(meassurements[0]);
                int w = int.Parse(meassurements[1]);
                int h = int.Parse(meassurements[2]);

                paper += 2 * l * w + 2 * w * h + 2 * h * l + Math.Min(l * w, Math.Min(w * h, l * h));
            }

            IO.Output(paper, 1);

            Console.WriteLine("Part 2:");

            int ribbon = 0;

            foreach (string row in input)
            {
                string[] meassurements = row.Split('x');

                int l = int.Parse(meassurements[0]);
                int w = int.Parse(meassurements[1]);
                int h = int.Parse(meassurements[2]);

                //int volume = l * w * h;

                ribbon += 2 * l + 2 * w + 2 * h - 2 * Helper.Max(new int[] { l, w, h }) + l*w*h;
            }

            IO.Output(ribbon, 2);

            Console.ReadKey();
        }
    }
}
