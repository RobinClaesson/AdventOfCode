using System;
using AoC;

namespace Day_1_2015
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = IO.Input;



            Console.WriteLine("Part 1:");
            int floor = 0;

            foreach (char c in input)
                if (c == '(')
                    floor++;
                else floor--;


            IO.Output(floor);

            Console.WriteLine("Part 2: ");
            floor = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                    floor++;
                else floor--;

                if (floor == -1)
                {
                    IO.Output(i+1);
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
