using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day1
{
    class Day1
    {
        static void Main(string[] args)
        {
            List<int> input = IO.InputRows_Int;

            int increased = 0;
            for (int i = 1; i < input.Count; i++)
                if (input[i] > input[i - 1])
                    increased++;

            IO.Output(increased);

            increased = 0;
            for (int i = 1; i < input.Count - 2; i++)
            {
                int curr = input[i] + input[i + 1] + input[i + 2];
                int prev = input[i - 1] + input[i] + input[i + 1];

                if (prev < curr)
                    increased++;
            }

            IO.Output(increased);
            Console.ReadKey();

        }
    }
}
