using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_7
{
    class Amplifier
    {
        List<int> program = IO.InputSplitted_Int(',');
        //List<int> program = Input.GetSeparatedInputList_Int(',');
        int programPosition = 0;
        public int output = 0, lastOpcode = -1;


        public Amplifier(int phase)
        {
            //Compute(phase);

            int adress = program[1];
            program[adress] = phase;
            programPosition += 2;
        }

        public void Compute(int input)
        {
            int opcode = -1;

            while (!(opcode == 99 || opcode == 4))
            {
                string instruction = "" + program[programPosition];

                while (instruction.Length < 5)
                    instruction = "0" + instruction;

                opcode = int.Parse(instruction.Substring(instruction.Length - 2));

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

                    output = program[adress];
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

            lastOpcode = opcode;

        }
    }
}
