using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            int valid1 = 0, valid2 = 0;

            foreach(string row in input)
            {
                string[] info = row.Replace(":", "").Replace("-", " ").Split(' ');

                int first = int.Parse(info[0]);
                int second = int.Parse(info[1]);
                char letter = info[2][0];

                //Part 1
                int count = 0;
                for (int i = 0; i < info[3].Length; i++)
                    if (info[3][i] == letter)
                        count++;

                if (count >= first && count <= second)
                    valid1++;

                //Part 2
                if (info[3][first - 1] == letter ^ info[3][second - 1] == letter)
                    valid2++;
            }

            IO.Output(valid1);
            IO.Output(valid2);
            Console.ReadKey();
        }
    }
}
