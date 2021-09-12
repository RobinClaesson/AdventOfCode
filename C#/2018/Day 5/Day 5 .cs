using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = IO.Input;

            //Part 1
            IO.Output(CollapsedLength(input));

            //Part 2
            int shortest = int.MaxValue;
            for (char c = 'a'; c <= 'z'; c++)
            {
                List<char> removed = input.ToList();
                removed.RemoveAll(i => i == c);
                removed.RemoveAll(i => i == (c - 32));

                int length = CollapsedLength(new string(removed.ToArray()));

                if (length < shortest)
                    shortest = length;
            }

            IO.Output(shortest);
            Console.ReadKey();

        }

        private static int CollapsedLength(string input)
        {
            bool changed = true;
            //Console.WriteLine(input);
            while (changed)
            {
                changed = false;

                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (Math.Abs(input[i] - input[i + 1]) == 32)
                    {
                        input = input.Substring(0, i) + input.Substring(i + 2);
                        //Console.WriteLine(input);
                        changed = true;
                    }
                }
            }

            return input.Length;
        }
    }
}
