using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Day8
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted('|');

            //Part1
            int part1 = 0;
            for (int i = 0; i < input.Count; i++)
            {
                //Filter out 1,4,7,8 
                part1 += input[i][1].Split(' ').Where(o => o != "" && (o.Length < 5 || o.Length == 7)).Count();
            }
            IO.Output(part1);


            //Part 2
            int part2 = 0;
            foreach (string[] row in input)
            {
                //Find the mixed wires
                List<string> pattern = row[0].Split(' ').Where(p => p != "").OrderBy(p => p.Length).ToList();
                Dictionary<char, char> sub = new Dictionary<char, char>();

                //We know index of 1 (0), 7 (1), 4(2) and 8(9) because their unique length


                //a = the one thats in 7 but not in 1 
                sub.Add(pattern[1].Except(pattern[0]).First(), 'a');

                //c = the one that is in 1 and in a total of 8 patterns
                //f = the one that is in 9 and a total of 9 patterns
                foreach (char c in pattern[0])
                {
                    int count = pattern.Count(p => p.Contains(c));

                    if (count == 8)
                        sub.Add(c, 'c');
                    else
                        sub.Add(c, 'f');
                }
                Char test = sub.Keys.ElementAt(0);
                //patter of 3 is the one with length 5, that contains a, c, f (all keys found)
                string three = pattern.Where(p => p.Length == 5).Where(p => p.Contains(sub.Keys.ElementAt(0))).Where(p => p.Contains(sub.Keys.ElementAt(1))).Where(p => p.Contains(sub.Keys.ElementAt(2))).First();

                //d = the one that is in 4, ins not c or f, and is in 3
                sub.Add(pattern[2].Intersect(three).Where(c => !sub.ContainsKey(c)).First(), 'd');

                //g = the one that is in 3 but not already found
                sub.Add(three.Where(c => !sub.ContainsKey(c)).First(), 'g');

                //The ones that are left are the ones in 8 that is not found
                //e = the one that is left and is not in 4
                sub.Add(pattern[9].Where(c => !sub.ContainsKey(c)).Except(pattern[2]).First(), 'e');

                //b = the one left
                sub.Add(pattern[9].Where(c => !sub.ContainsKey(c)).First(), 'b');

                //Translate all outputs
                List<string> output = row[1].Split(' ').Where(o => o != "").ToList();
                for (int i = 0; i < output.Count; i++)
                {
                    string translated = "";

                    foreach (char c in output[i])
                        translated += sub[c];


                    output[i] = translated;
                }


                //Translate to digits and add value
                string digits = "";
                foreach (string o in output)
                    digits += SevenSegmentValue(o);

                part2 += int.Parse(digits);
            }


            IO.Output(part2);
            Console.ReadKey();
        }

        public static int SevenSegmentValue(string signal)
        {
            signal = String.Concat(signal.OrderBy(c => c));

            switch (signal)
            {
                default: return 0;
                case "abcdfg": return 9;
                case "abcdefg": return 8;
                case "acf": return 7;
                case "abdefg": return 6;
                case "abdfg": return 5;
                case "bcdf": return 4;
                case "acdfg": return 3;
                case "acdeg": return 2;
                case "cf": return 1;
            }
        }

    }
}
