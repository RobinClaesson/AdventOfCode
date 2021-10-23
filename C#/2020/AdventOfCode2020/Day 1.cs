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
            int answer = -1;
            for (int i = 0; i < input.Count; i++)
                for (int j = i + 1; j < input.Count; j++)
                    if ((input[i] + input[j]) == 2020)
                    {
                        answer = input[i] * input[j];
                    }

            IO.Output(answer);

            //Part 2
            for (int i = 0; i < input.Count; i++)
                for (int j = i + 1; j < input.Count; j++)
                    for (int k = j + 1; k < input.Count; k++)
                        if ((input[i] + input[j] + input[k]) == 2020)
                        {
                            answer = input[i] * input[j] * input[k];
                        }
            IO.Output(answer);

            Console.ReadKey();
        }
    }
}
