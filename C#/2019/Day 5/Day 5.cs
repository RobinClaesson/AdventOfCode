using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC_IO;

namespace Day_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1:");
            Console.WriteLine(Compute(1));

            Console.WriteLine("------------------------");

            Console.WriteLine("Part 2:");
            string answer = Compute(5);
            Console.WriteLine(answer);
            Output.SaveToClipboard(answer);

            Console.ReadKey();
        }

        public static string Compute(int input)
        {
            string output = "";
            List<int> program = Input.GetSeparatedInputList_Int(',');
            int programPosition = 0;

            while (program[programPosition] != 99)
            {
                string instruction = "" + program[programPosition];

                while (instruction.Length < 5)
                    instruction = "0" + instruction;

                int opcode = int.Parse(instruction.Substring(instruction.Length - 2));

                List<char> parameterModes = instruction.Substring(0, instruction.Length - 2).ToList<char>();


                if (opcode == 1)
                {
                    int p1 = program[programPosition + 1], p2 = program[programPosition + 2],
                        p3 = program[programPosition + 3];

                    if (parameterModes[2] == '0')
                        p1 = program[p1];

                    if (parameterModes[1] == '0')
                        p2 = program[p2];

                    program[p3] = p1 + p2;
                    programPosition += 4;
                }

                else if (opcode == 2)
                {
                    int p1 = program[programPosition + 1], p2 = program[programPosition + 2],
                        p3 = program[programPosition + 3];

                    if (parameterModes[2] == '0')
                        p1 = program[p1];

                    if (parameterModes[1] == '0')
                        p2 = program[p2];

                    program[p3] = p1 * p2;
                    programPosition += 4;
                }

                else if (opcode == 3)
                {
                    int adress = program[programPosition + 1];
                    program[adress] = input;
                    programPosition += 2;
                }

                else if (opcode == 4)
                {
                    int adress = programPosition + 1;
                    if (parameterModes[2] == '0')
                        adress = program[adress];

                    if (output != "")
                        output += ", ";

                    output += program[adress];
                    programPosition += 2;
                }

                else if (opcode == 5)
                {
                    int p1 = program[programPosition + 1], p2 = program[programPosition + 2];

                    if (parameterModes[2] == '0')
                        p1 = program[p1];

                    if (parameterModes[1] == '0')
                        p2 = program[p2];

                    if (p1 != 0)
                        programPosition = p2;

                    else
                        programPosition += 3;
                }

                else if (opcode == 6)
                {
                    int p1 = program[programPosition + 1], p2 = program[programPosition + 2];

                    if (parameterModes[2] == '0')
                        p1 = program[p1];

                    if (parameterModes[1] == '0')
                        p2 = program[p2];

                    if (p1 == 0)
                        programPosition = p2;

                    else
                        programPosition += 3;
                }

                else if (opcode == 7)
                {
                    int p1 = program[programPosition + 1], p2 = program[programPosition + 2],
                        p3 = program[programPosition + 3];

                    if (parameterModes[2] == '0')
                        p1 = program[p1];

                    if (parameterModes[1] == '0')
                        p2 = program[p2];


                    if (p1 < p2)
                        program[p3] = 1;
                    else
                        program[p3] = 0;

                        programPosition += 4;
                }

                else if (opcode == 8)
                {
                    int p1 = program[programPosition + 1], p2 = program[programPosition + 2],
                        p3 = program[programPosition + 3];

                    if (parameterModes[2] == '0')
                        p1 = program[p1];

                    if (parameterModes[1] == '0')
                        p2 = program[p2];


                    if (p1 == p2)
                        program[p3] = 1;
                    else
                        program[p3] = 0;

                    programPosition += 4;
                }

            }

            return output;
        }
    }
}
