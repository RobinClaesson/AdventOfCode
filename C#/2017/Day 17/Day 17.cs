using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = IO.Input_Int;

            //Part 1
            List<int> spinlock = Spinlock(steps, 2017, false);

            IO.Output(spinlock[spinlock.IndexOf(2017) + 1]);

            //Part 2
            IO.Output(SecondValueInSpinlock(steps, 50000000));

            Console.ReadKey();
        }

        private static List<int> Spinlock(int steps, int spins, bool printProgress)
        {
            List<int> spinlock = new List<int>() { 0 };
            int pos = 0;

            for (int i = 1; i <= spins; i++)
            {
                if (printProgress)
                    Helper.PrintProgress(true, i, spins, 10);

                pos += steps;
                pos = ((pos + spinlock.Count) % spinlock.Count) + 1;

                spinlock.Insert(pos, i);
            }

            return spinlock;
        }

        
        private static int SecondValueInSpinlock(int steps, int spins)
        {
            int value = 0;
            int pos = 0;
            for (int i = 1; i <= spins; i++)
            {
                //This doesnt keep track of the spinlock just the second value (0 is alwayst first)
                //The length of the list would have been i, so we use that to calculate what pos we should have had
               
                pos += steps;
                pos = ((pos + i) % i) + 1;

                if (pos == 1)
                    value = i;
            }


            return value;
        }

    }
}
