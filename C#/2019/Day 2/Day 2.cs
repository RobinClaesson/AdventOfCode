using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();

            int a = 0, b = 0;
            int desiredOutput = 19690720;

            bool found = false;

            while(!found)
            {
                if (Compute(a, b) == desiredOutput)
                {
                    IO.Output("" + ((100 * a) + b), true);
                    found = true;
                }
                else if (Compute(b, a) == desiredOutput)
                {
                    IO.Output("" + ((100 * b) + a), true);
                    found = true;
                }

                else
                {
                    a++;

                    if(a > b)
                    {
                        b++;
                        a = 0;
                    }
                }

            }

            //Console.WriteLine("" + ((100*noun) + verb));
            Console.ReadKey();
        }

        private static int Compute(int noun, int verb)
        {
            List<int> input = IO.InputSplitted_Int(',');
            //List<int> input = Input.GetSeparatedInputList_Int(',');

            input[1] = noun;
            input[2] = verb;

            int pos = 0;

            while (input[pos] != 99)
            {
                int a = input[pos + 1];
                int b = input[pos + 2];
                int c = input[pos + 3];

                if (input[pos] == 1)
                {
                    input[c] = input[a] + input[b];
                }

                else if (input[pos] == 2)
                {
                    input[c] = input[a] * input[b];
                }

                pos += 4;
            }

            return (input[0]);
        }

        private static void Part1()
        {
            IO.Output(Compute(12, 2));           
        }
    }
}
