using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Day7
    {
        static void Main(string[] args)
        {
            List<int> input = IO.InputSplitted_Int(',');
            input.Sort();

            int part1 = int.MaxValue;
            int part2 = int.MaxValue;
            for (int i = 0; i < input.Count; i++)
            {
                //Part 1
                int sum = 0;
                for (int j = 0; j < input.Count; j++)
                    sum += Math.Abs(input[i] - input[j]);

                if (sum < part1)
                    part1 = sum;

                //Part 2
                sum = 0;
                for (int j = 0; j < input.Count; j++)
                {

                    int diff = Math.Abs(input[i] - input[j]);

                    //if(diff > 0)
                    //for (int k = 1; k <= diff; k++)
                    //    sum += k;

                    sum += (diff * (diff + 1)) / 2;
                }
                if (sum < part2)
                    part2 = sum;
            }

            IO.Output(part1);
            IO.Output(part2);
            Console.ReadKey();
        }
    }
}
