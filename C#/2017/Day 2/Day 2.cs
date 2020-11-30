using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> input = IO.InputRowsSplitted_Int('\t');

            //Part 1
            int sum = 0;
            foreach (int[] row in input)
            {
                sum += row.Max() - row.Min();
            }

            IO.Output(sum);

            //Part 2
            sum = 0;
            foreach (int[] row in input)
            {
                for (int i = 0; i < row.Length; i++)
                    for (int j = 0; j < row.Length; j++)
                        if (i != j && row[i] % row[j] == 0)
                            sum += row[i] / row[j];
            }


            IO.Output(sum);
            Console.ReadKey();
        }
    }
}
