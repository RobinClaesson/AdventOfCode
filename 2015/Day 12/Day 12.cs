using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_12
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = IO.Input;
            Part1(input);



            Console.ReadKey();

        }

        private static void Part1(string input)
        {
            char[] allowed = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '-' };

            int i = 0;
            while (i < input.Length)
            {
                if (!allowed.Contains(input[i]))
                {
                    input = input.Remove(i, 1);
                }

                else
                    i++;
            }

            int sum = 0;
            string[] numbers = input.Split(',');

            for (i = 0; i < numbers.Length; i++)
                if (numbers[i] != "")
                    sum += int.Parse(numbers[i]);

            IO.Output(sum);

        }
    }
}
