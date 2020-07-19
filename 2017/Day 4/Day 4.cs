using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted(' ');

            int validCount = 0;
            for (int i = 0; i < input.Count; i++)
            {
                bool valid = true;
                for (int j = 0; j < input[i].Length; j++)
                    for (int k = 0; k < input[i].Length; k++)
                        if (j != k && input[i][j] == input[i][k])
                        {
                            valid = false;
                            break;
                        }

                if (valid)
                    validCount++;
            }
            IO.Output(validCount);


            //Part 2
            validCount = 0;
            for (int i = 0; i < input.Count; i++)
            {
                bool valid = true;
                for (int j = 0; j < input[i].Length; j++)
                    for (int k = 0; k < input[i].Length; k++)
                    {
                        if (j != k && input[i][j].All(input[i][k].Contains) && input[i][j].Length == input[i][k].Length)
                        {
                            valid = false;
                            break;
                        }
                    }

                if (valid)
                    validCount++;
            }
            IO.Output(validCount);
            Console.ReadKey();
        }
    }
}
