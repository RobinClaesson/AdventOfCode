using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<string> input = IO.InputRows;

            //Part 1
            int niceStrings = 0;
            foreach(string row in input)
            {
                if (IsNicePart1(row))
                    niceStrings++;
            }

            IO.Output(niceStrings);

            //Part 2
            niceStrings = 0;
            foreach (string row in input)
            {
                if (IsNicePart2(row))
                    niceStrings++;
            }

            IO.Output(niceStrings, true);

            Console.ReadKey();
        }

        private static bool IsNicePart1(string s)
        {
            if (s.Contains("ab") || s.Contains("cd") || s.Contains("pq") || s.Contains("xy"))
                return false;

            else
            {
                string vowels = "aeiou";
                int vCount = 0;
                bool gotDouble = false;

                if (vowels.Contains(s[0]))
                    vCount++;

                for(int i = 1; i < s.Length; i++)
                {
                    if (vowels.Contains(s[i]))
                        vCount++;

                    if (s[i] == s[i - 1])
                        gotDouble = true;
                }

                return (vCount > 2 && gotDouble);
            }
        }

        private static bool IsNicePart2(string s)
        {
            bool hasDouble = false, oneBetween = false;

            int i = 0; 
            while(i < s.Length-2)
            {
                if (s[i] == s[i + 2])
                    oneBetween = true;

                for(int j = i+2; j < s.Length-1; j++)
                {
                    if (s.Substring(i, 2) == s.Substring(j, 2))
                        hasDouble = true;
                }

                i++;
            }

            return (oneBetween && hasDouble);
        }
    }
}
