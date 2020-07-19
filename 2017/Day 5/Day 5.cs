using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = IO.InputRows_Int;

            //Part 1
            int i = 0;
            int steps = 0;
            while (i < input.Count)
            {
                int nextI = i + input[i];
                input[i]++;
                i = nextI;
                steps++;
            }

            IO.Output(steps);

            //Part 2
            input = IO.InputRows_Int;

            i = 0;
            steps = 0;
            while (i < input.Count)
            {
                int nextI = i + input[i];

                if (input[i] < 3)
                    input[i]++;
                else
                    input[i]--;

                i = nextI;
                steps++;
            }

            IO.Output(steps);



            Console.ReadKey();
        }
    }
}
