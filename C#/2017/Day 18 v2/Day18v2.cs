using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_18_v2
{
    class Day18v2
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted(' ');


            Part1(input);
            Part2(input);
            Console.ReadKey();
        }

        private static void Part1(List<string[]> input)
        {
            Register register = new Register();

            while (register.RecoverdSound == 0)
            {
                if (input[register.CurrentInstruction][0].Equals("snd"))
                {
                    register.Play(input[register.CurrentInstruction][1].First());
                }

                else if (input[register.CurrentInstruction][0] == "rcv")
                {
                    register.RecoverOwn(input[register.CurrentInstruction][1].First());
                }

                else
                {
                    char toModify = input[register.CurrentInstruction][1].First();
                    int value = 0;
                    char valueFrom = ' ';

                    if (!int.TryParse(input[register.CurrentInstruction][2], out value))
                        valueFrom = input[register.CurrentInstruction][2].First();


                    switch (input[register.CurrentInstruction][0])
                    {
                        default:
                        case "set":

                            if (valueFrom == ' ')
                                register.Set(toModify, value);
                            else
                                register.Set(toModify, valueFrom);

                            break;

                        case "add":
                            if (valueFrom == ' ')
                                register.Add(toModify, value);
                            else
                                register.Add(toModify, valueFrom);
                            break;

                        case "mul":
                            if (valueFrom == ' ')
                                register.Mul(toModify, value);
                            else
                                register.Mul(toModify, valueFrom);
                            break;

                        case "mod":
                            if (valueFrom == ' ')
                                register.Mod(toModify, value);
                            else
                                register.Mod(toModify, valueFrom);

                            break;

                        case "jgz":
                            if (valueFrom == ' ')
                                register.Jump(toModify, value);
                            else
                                register.Jump(toModify, valueFrom);
                            break;
                    }
                }
            }

            IO.Output(register.RecoverdSound);
        }

        private static void Part2(List<string[]> input)
        {
            Register[] registers = new Register[2];
            registers[0] = new Register(0);
            registers[1] = new Register(1);

            int last = 0;
            while (registers[0].Running || registers[1].Running)
            {
                DoInstruction(input, registers[0], registers[1]);
                DoInstruction(input, registers[1], registers[0]);

                //if (last == 7620)
                //{
                //    Console.WriteLine("Register 0: \r\n" + registers[0]);
                //    Console.WriteLine("----------------------------------------------------");
                //    Console.WriteLine("Register 1: \r\n" + registers[1]);

                //    Console.ReadKey();

                //    //Console.WriteLine("\r\n ----NEXT STEP----");
                //    Console.Clear();
                //}

                //if (registers[1].TimesPlayed != last)
                //{
                //    last = registers[1].TimesPlayed;
                //    Console.WriteLine(last);
                //}
            }


            IO.Output(registers[1].TimesPlayed);
        }

        private static void DoInstruction(List<string[]> input, Register register, Register other)
        {

            if (input[register.CurrentInstruction][0].Equals("snd"))
            {
                int value = 0;
                char valueFrom = ' ';

                if (!int.TryParse(input[register.CurrentInstruction][1], out value))
                    valueFrom = input[register.CurrentInstruction][1].First();

                if (valueFrom != ' ')
                    register.Play(valueFrom, other);
                else
                    register.Play(value, other);
            }

            else if (input[register.CurrentInstruction][0] == "rcv")
            {
                register.Recover(input[register.CurrentInstruction][1].First());
            }

            else
            {
                char toModify = input[register.CurrentInstruction][1].First();
                int value = 0;
                char valueFrom = ' ';

                if (!int.TryParse(input[register.CurrentInstruction][2], out value))
                    valueFrom = input[register.CurrentInstruction][2].First();


                switch (input[register.CurrentInstruction][0])
                {
                    default:
                    case "set":

                        if (valueFrom == ' ')
                            register.Set(toModify, value);
                        else
                            register.Set(toModify, valueFrom);

                        break;

                    case "add":
                        if (valueFrom == ' ')
                            register.Add(toModify, value);
                        else
                            register.Add(toModify, valueFrom);
                        break;

                    case "mul":
                        if (valueFrom == ' ')
                            register.Mul(toModify, value);
                        else
                            register.Mul(toModify, valueFrom);
                        break;

                    case "mod":
                        if (valueFrom == ' ')
                            register.Mod(toModify, value);
                        else
                            register.Mod(toModify, valueFrom);

                        break;

                    case "jgz":
                        if (int.TryParse(toModify + "", out int jumpValue))
                        {
                            register.Jump(jumpValue, value);

                        }
                        else
                        {
                            if (valueFrom == ' ')
                                register.Jump(toModify, value);
                            else
                                register.Jump(toModify, valueFrom);
                        }

                        break;
                }

            }
        }
    }
}
