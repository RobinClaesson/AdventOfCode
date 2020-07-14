using AoC;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day_23
{
    class Program
    {
        static void Main(string[] args)
        {
            IO.ClearLogFile();

            IO.Output(CalculateB(0, false));
            IO.Output(CalculateB(1, false));
            

            Console.ReadKey();
        }

        private static int CalculateB(int a, bool log)
        {
            List<string[]> input = IO.InputRowsSplitted(' ');
            int i = 0, b = 0;
            while (i < input.Count())
            {
                string instruction = input[i][0];

                //hlf
                if (instruction == "hlf")
                {

                    if (log)
                        IO.Log("-Before instruction-\r\ni:" + i + " | instr:" + instruction + " | a:" + a + " | b:" + b);

                    string reg = input[i][1];


                    if (reg.Contains("a"))
                        a /= 2;
                    else
                        b /= 2;

                    i++;

                    if (log)
                        IO.Log("-After instruction-\r\ni:" + i + " | reg:" + reg + " | a:" + a + " | b:" + b + "\r\n------------------");
                }

                else if (instruction == "tpl")
                {
                    if (log)
                        IO.Log("-Before instruction-\r\ni:" + i + " | instr:" + instruction + " | a:" + a + " | b:" + b);

                    string reg = input[i][1];

                    if (reg.Contains("a"))
                        a *= 3;
                    else
                        b *= 3;

                    i++;

                    if (log)
                        IO.Log("-After instruction-\r\ni:" + i + " | reg:" + reg + " | a:" + a + " | b:" + b + "\r\n------------------");
                }

                else if (instruction == "inc")
                {

                    if (log)
                        IO.Log("-Before instruction-\r\ni:" + i + " | instr:" + instruction + " | a:" + a + " | b:" + b);

                    string reg = input[i][1];

                    if (reg.Contains("a"))
                        a++;
                    else
                        b++;

                    i++;

                    if (log)
                        IO.Log("-After instruction-\r\ni:" + i + " | reg:" + reg + " | a:" + a + " | b:" + b + "\r\n------------------");
                }

                else if (instruction == "jmp")
                {
                    if (log)
                        IO.Log("-Before instruction-\r\ni:" + i + " | instr:" + instruction + " | a:" + a + " | b:" + b);

                    int off = int.Parse(input[i][1]);
                    i += off;

                    if (log)
                        IO.Log("-After instruction-\r\ni:" + i + " | off:" + off + " | a:" + a + " | b:" + b + "\r\n------------------");
                }

                else if (instruction == "jie")
                {
                    if (log)
                        IO.Log("-Before instruction-\r\ni:" + i + " | instr:" + instruction + " | a:" + a + " | b:" + b);
                    string reg = input[i][1];

                    int value;

                    if (reg.Contains("a"))
                        value = a;
                    else
                        value = b;

                    int off = int.Parse(input[i][2]);
                    bool jump = (value % 2 == 0);

                    if (jump)
                        i += off;

                    else i++;

                    if (log)
                        IO.Log("-After instruction-\r\ni:" + i + " | reg:" + reg + " | off:" + off + " | jump:" + jump + " | a:" + a + " | b:" + b + "\r\n------------------");

                }

                else if (instruction == "jio")
                {
                    if (log)
                        IO.Log("-Before instruction-\r\ni:" + i + " | instr:" + instruction + " | a:" + a + " | b:" + b);

                    string reg = input[i][1];

                    int value;

                    if (reg.Contains("a"))
                        value = a;
                    else
                        value = b;

                    int off = int.Parse(input[i][2]);
                    bool jump = (value == 1);

                    if (jump)
                        i += off;

                    else i++;

                    if (log)
                        IO.Log("-After instruction-\r\ni:" + i + " | reg:" + reg + " | off:" + off + " | jump:" + jump + " | a:" + a + " | b:" + b + "\r\n------------------");

                }
            }

            if(log)
            {
                IO.Log("b = " + b);
                IO.WriteLogToFile();
            }

            return b;
        }
    }
}
