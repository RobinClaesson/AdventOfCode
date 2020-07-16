using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> input = IO.InputRowsSplitted_Int(' ');

            int valid = 0;

            //Part 1
            foreach (int[] sides in input)
            {
                if (IsValid(sides))
                {
                    valid++;
                }
            }

            IO.Output(valid);


            //Part 2
            valid = 0;
            for(int x = 0; x < input[0].Length; x++)
            {
                for(int y = 0; y < input.Count; y += 3)
                {
                    if (IsValid(new int[] { input[y][x], input[y + 1][x], input[y + 2][x] }))
                        valid++;
                }
            }
            IO.Output(valid);

            Console.ReadKey();
        }

        static bool IsValid(int[] sides)
        {
            return (sides[0] + sides[1] > sides[2] && sides[2] + sides[1] > sides[0] && sides[0] + sides[2] > sides[1]);
        }
    }
}
