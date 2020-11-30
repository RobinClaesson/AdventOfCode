using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC_IO;
using IntcodeComputer;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer intComp = new Computer(Input.GetSeparatedInputList_Long(','));

            Console.WriteLine("Part 1");
            intComp.Input = 1;
            intComp.ComputeToEnd(true, false);
            Output.PresentAnswer(intComp.Output);

            intComp.Reset();
            Console.WriteLine("Part 1");
            intComp.Input = 2;
            intComp.ComputeToEnd();
            Output.PresentAnswer(intComp.Output);

            Console.ReadKey();
        }



    }
}
