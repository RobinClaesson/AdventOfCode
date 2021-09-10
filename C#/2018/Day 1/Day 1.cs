using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = IO.InputRows_Int;

            //Part 1
            IO.Output(input.Sum());

            //Part 2
            List<int> sums = new List<int>();
            sums.Add(0);
            bool match = false;

            while (!match)
                for (int i = 0; i < input.Count; i++)
                {
                    int sum = sums.Last() + input[i];

                    if (sums.IndexOf(sum) != -1)
                    {
                        match = true;
                        IO.Output(sum);
                        break;
                    }

                    sums.Add(sum);
                }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
