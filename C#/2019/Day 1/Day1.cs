using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_1
{
    class Day1
    {
        static void Main(string[] args)
        {
            List<int> input = IO.InputRows_Int;

            int fuel = 0;

            foreach (int module in input)
                fuel += (module / 3) - 2;

            IO.Output(fuel);

            fuel = 0;

            foreach (int module in input)
            {
                int fuelToAdd = (module / 3) - 2;

                while(fuelToAdd > 0)
                {
                    fuel += fuelToAdd;

                    fuelToAdd = (fuelToAdd / 3) - 2;
                }
            }

            IO.Output(fuel, true);
            Console.ReadKey();
        }
    }
}
