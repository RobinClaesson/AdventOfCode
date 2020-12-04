using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_23
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            //Part 1
            Register register = new Register(input, 0);
            while (register.Running)
            {
                register.Update();
            }

            IO.Output(register.TimesMul);

            //Part 2
             register = new Register(input, 1);
            while (register.Running)
            {
                register.Update();

                if (register.UpdatesDone % 10000000 == 0)
                    Console.WriteLine(register.ToString());
            }

            IO.Output(register.GetValue('h'));
            Console.ReadKey();
        }
    }
}
