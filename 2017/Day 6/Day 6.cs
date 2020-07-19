using AoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = IO.InputSplitted_Int('\t').ToArray();
            IO.Output(StepsToRepeat(input));
            IO.Output(StepsBetweenRepeat(input));
            Console.ReadKey();
        }

        static private int StepsToRepeat(int[] input)
        {
            HashSet<string> seen = new HashSet<string>();

            string s = "";
            foreach (int i in input)
                s += i + ",";

            seen.Add(s);

            int steps = 0;
            bool looped = false;
            while (!looped)
            {
                steps++;

                int index = 0;
                for (int i = 1; i < input.Length; i++)
                    if (input[i] > input[index])
                        index = i;

                int toAllocate = input[index];
                input[index] = 0;

                while (toAllocate > 0)
                {
                    index++;

                    if (index >= input.Length)
                        index -= input.Length;

                    input[index]++;
                    toAllocate--;
                }

                s = "";
                foreach (int i in input)
                    s += i + ",";

                if (seen.Contains(s))
                    looped = true;

                else
                    seen.Add(s);
            }

            return steps;
        }

        static private int StepsBetweenRepeat(int[] input)
        {
            List<string> seen = new List<string>();

            string s = "";
            foreach (int i in input)
                s += i + ",";

            seen.Add(s);

            int steps = 0;
            bool looped = false;
            while (!looped)
            {
                steps++;

                int index = 0;
                for (int i = 1; i < input.Length; i++)
                    if (input[i] > input[index])
                        index = i;

                int toAllocate = input[index];
                input[index] = 0;

                while (toAllocate > 0)
                {
                    index++;

                    if (index >= input.Length)
                        index -= input.Length;

                    input[index]++;
                    toAllocate--;
                }

                s = "";
                foreach (int i in input)
                    s += i + ",";

                if (seen.Contains(s))
                {
                    return seen.Count - seen.IndexOf(s);
                }

                else
                    seen.Add(s);
            }

            return -1;
        }
    }
}
