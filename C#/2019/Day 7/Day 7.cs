using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC_IO;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Part1();

            //Part 2
            Console.WriteLine("Part 2:");
            int maxOutput = 0;
            List<int[]> phaseSettings = new List<int[]>();
            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++)
                    for (int c = 0; c < 5; c++)
                        for (int d = 0; d < 5; d++)
                            for (int e = 0; e < 5; e++)
                            {
                                int[] setting = new int[] { a+5, b+5, c+5, d+5, e+5 };
                                if (setting.Distinct().Count() == setting.Length)
                                    phaseSettings.Add(setting);
                            }


            foreach(int[] setting in phaseSettings)
            {
                Amplifier[] amplifiers = new Amplifier[] {  new Amplifier(setting[0]),
                                                            new Amplifier(setting[1]),
                                                            new Amplifier(setting[2]),
                                                            new Amplifier(setting[3]),
                                                            new Amplifier(setting[4])};

                //This should provide correct phase for ex2
                //amplifiers = new Amplifier[] { new Amplifier(9), new Amplifier(7), new Amplifier(8), new Amplifier(5), new Amplifier(6) };

                int output = 0;
                do
                {
                    amplifiers[0].Compute(output);
                    amplifiers[1].Compute(amplifiers[0].output);
                    amplifiers[2].Compute(amplifiers[1].output);
                    amplifiers[3].Compute(amplifiers[2].output);
                    amplifiers[4].Compute(amplifiers[3].output);

                    

                    output = amplifiers[4].output;
                } while (amplifiers[4].lastOpcode != 99);

                if (output > maxOutput)
                    maxOutput = output;
            }

            Output.PresentAnswer(maxOutput);
            Console.ReadKey();
        }

        private static void Part1()
        {
            Console.WriteLine("Part 1:");
            //Creates all leagal Phasesettings
            int maxOutput = 0;
            List<int[]> phaseSettings = new List<int[]>();
            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++)
                    for (int c = 0; c < 5; c++)
                        for (int d = 0; d < 5; d++)
                            for (int e = 0; e < 5; e++)
                            {
                                int[] setting = new int[] { a, b, c, d, e };
                                if (setting.Distinct().Count() == setting.Length)
                                    phaseSettings.Add(setting);
                            }


            foreach (int[] setting in phaseSettings)
            {
                int output = RunAmps(setting);

                if (output > maxOutput)
                    maxOutput = output;
            }

            
            Output.PresentAnswer(maxOutput);
        }

        static string Compute(int[] input)
        {
            int inputUsed = 0;
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
                    program[adress] = input[inputUsed];
                    inputUsed++;
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

        static int RunAmps(int[] pahseSetting)
        {
            int lastOutput = 0;
            for (int i = 0; i < pahseSetting.Length; i++)
            {
                int[] input = new int[] { pahseSetting[i], lastOutput };
                lastOutput = int.Parse(Compute(input));
            }


            return lastOutput;
        }

    }
}
