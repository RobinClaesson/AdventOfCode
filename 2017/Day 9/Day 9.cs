using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> input = IO.Input.ToList();

            int sum = 0, layer = 0, garbage = 0;
            for (int i = 0; i < input.Count; i++)
            {
                //Start of garbage
                if (input[i] == '<')
                {
                    int length = 1;

                    while (input[i + length] != '>')
                    {
                        //If we see a ! we jump a extra step
                        if (input[i + length] == '!')
                            input.RemoveRange(i + length, 2);
                        else
                            length++;
                    }

                    garbage += length - 1;
                    input.RemoveRange(i, length + 1);
                    i--;
                }

                else if (input[i] == '{')
                    layer++;

                else if (input[i] == '}')
                {
                    sum += layer;
                    layer--;
                }

            }

            IO.Output(sum);
            IO.Output(garbage);
            Console.ReadKey();
        }
    }
}
