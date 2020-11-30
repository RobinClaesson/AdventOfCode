using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_20
{
    class Program
    {
        static void Main()
        {
            int input = IO.Input_Int;

            //Part 1
            int house = 0;
            int presents;
            do
            {
                house++;
                presents = Factor(house).Sum() * 10;
                

            } while (presents < input);

            IO.Output(house);

            //Part 2

            house = 0;

            do
            {
                house++;
                presents = 0;

                List<int> factors = Factor(house);
                
                foreach(int factor in factors)
                {
                    if (factor * 50 >= house)
                        presents += 11 * factor;
                }


            } while (presents < input);

            IO.Output(house, true);

            Console.ReadKey();

        }

        public static List<int> Factor(int number)
        {
            //https://stackoverflow.com/questions/239865/best-way-to-find-all-factors-of-a-given-number
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            return factors;
        }
    }
}
