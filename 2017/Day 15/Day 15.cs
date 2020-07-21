using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted(' ');

            Generator genA = new Generator(16807, int.Parse(input[0].Last()));
            Generator genB = new Generator(48271, int.Parse(input[1].Last()));
            int part1 = CompareNumbers(genA, genB, 40000000, 1);

            genA = new Generator(16807, int.Parse(input[0].Last()), 4);
            genB = new Generator(48271, int.Parse(input[1].Last()), 8);
            int part2 = CompareNumbers(genA, genB, 5000000, 2);

            IO.Output(part1);
            IO.Output(part2);
            Console.ReadKey();
        }

        private static int CompareNumbers(Generator genA, Generator genB, int rounds, int part)
        {
            int judge = 0;
            for (int i = 0; i < rounds; i++)
            {
                if (i % (rounds / 20) == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Part {2} checked {0}/{1} numbers", i, rounds, part);
                }


                long a = genA.NextNumber();
                string numA = Convert.ToString(a, 2);
                if (numA.Length > 16)
                    numA = numA.Substring(numA.Length - 16);
                while (numA.Length < 16)
                    numA = "0" + numA;

                long b = genB.NextNumber();
                string numB = Convert.ToString(b, 2);
                if (numB.Length > 16)
                    numB = numB.Substring(numB.Length - 16);
                while (numB.Length < 16)
                    numB = "0" + numB;


                if (numA == numB)
                    judge++;

            }
            Console.Clear();
            return judge;
        }
    }


}
