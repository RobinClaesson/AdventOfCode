using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = IO.Input.ToCharArray();

            //Part 1
            int sum = 0;
            for(int i = 0; i < input.Length-1; i++)
            {
                if (input[i] == input[i + 1])
                    sum += int.Parse("" + input[i]);

            }

            if(input.Last() == input.First() && input.Length > 1)
                sum += int.Parse("" + input.First());

            IO.Output(sum);

            //Part 2
            sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int compareTo = (i + input.Length / 2);

                if (compareTo >= input.Length)
                    compareTo -= input.Length;

                if (input[i] == input[compareTo])
                    sum += int.Parse("" + input[i]);

            }

            IO.Output(sum);
            Console.ReadKey();
        }
    }
}
