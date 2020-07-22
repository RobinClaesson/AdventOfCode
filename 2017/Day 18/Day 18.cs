using AoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_18
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            IO.Output(Part1(input));
            

            Console.ReadKey();
        }

        private static long Part1(List<string> input)
        {
            Hashtable reg = new Hashtable();

            long sound = 0;
            bool log = false;
            long zero = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (log)
                    IO.Log(input[i]);

                string[] words = input[i].Split(' ');

                string instruction = words[0];
                string register = words[1];

                //Check if the second variable is a number and gets its value 
                string source = "";
                bool isNumber = false;
                long value = 0;
                if (words.Length > 2)
                {
                    source = words[2];
                    isNumber = long.TryParse(source, out value);
                }

                if (log)
                    IO.Log("Instruction:" + instruction + " | Register: " + register + " | IsNumber:" + isNumber + " | Value:" + value + " | Soure:" + source + " | i:" + i + "\r\n");


                //Adds the register if its new and not a number
                if (!reg.ContainsKey(register) && !long.TryParse(register, out _))
                    reg.Add(register, zero);

                if (instruction == "snd")
                {
                    //"Play" a sound (Sound only plays from registrers
                    sound = (long)reg[register];

                    if (log)
                    {
                        IO.Log("Register " + register + " has " + reg[register]);
                        IO.Log("Plays sound " + sound);
                    }
                }

                else if (instruction == "set")
                {
                    //Set a register to a value
                    if (isNumber)
                    {
                        if (log)
                            IO.Log("Register " + register + " has " + reg[register]);

                        reg[register] = (long)value;

                        if (log)
                        {
                            IO.Log("Sets register " + register + " to " + value);
                            IO.Log(register + " is now " + reg[register]);
                        }
                    }

                    else
                    {
                        if (log)
                        {
                            IO.Log("Register " + register + " has " + reg[register]);
                            IO.Log("Source " + source + " has value" + reg[source]);
                        }

                        reg[register] = (long)reg[source];

                        if (log)
                        {
                            IO.Log("Sets register " + register + " to " + source);
                            IO.Log(register + " is now " + reg[register]);
                        }
                    }
                }

                else if (instruction == "add")
                {
                    if (isNumber)
                    {
                        if (log)
                            IO.Log("Register " + register + " has " + reg[register]);

                        reg[register] = (long)reg[register] + value;

                        if (log)
                        {
                            IO.Log("Adds " + value + " to " + register);
                            IO.Log(register + " is now " + reg[register]);
                        }
                    }

                    else
                    {
                        if (log)
                        {
                            IO.Log("Register " + register + " has " + reg[register]);
                            IO.Log("Source " + source + " has value" + reg[source]);
                        }

                        reg[register] = (long)reg[register] + (long)reg[source];

                        if (log)
                        {
                            IO.Log("Adds " + source + " to " + register);
                            IO.Log(register + " is now " + reg[register]);
                        }
                    }
                }

                else if (instruction == "mul")
                {
                    if (isNumber)
                    {
                        if (log)
                            IO.Log("Register " + register + " has " + reg[register]);

                        reg[register] = (long)reg[register] * value;

                        if (log)
                        {
                            IO.Log("Multiply " + value + " with " + register);
                            IO.Log(register + " is now " + reg[register]);
                        }
                    }
                    else
                    {
                        if (log)
                        {
                            IO.Log("Register " + register + " has " + reg[register]);
                            IO.Log("Source " + source + " has value" + reg[source]);
                        }

                        reg[register] = (long)reg[register] * (long)reg[source];

                        if (log)
                        {
                            IO.Log("Multiply " + source + " to " + register);
                            IO.Log(register + " is now " + reg[register]);
                        }
                    }
                }

                else if (instruction == "mod")
                {
                    if (isNumber)
                    {
                        if (log)
                            IO.Log("Register " + register + " has " + reg[register]);

                        reg[register] = (long)reg[register] % value;

                        if (log)
                        {
                            IO.Log("Gets " + register + " modulu " + value);
                            IO.Log(register + " is now " + reg[register]);
                        }
                    }
                    else
                    {
                        if (log)
                        {
                            IO.Log("Register " + register + " has " + reg[register]);
                            IO.Log("Source " + source + " has value" + reg[source]);
                        }

                        reg[register] = (long)reg[register] % (long)reg[source];

                        if (log)
                        {
                            IO.Log("Gets " + register + " modulu " + source);
                            IO.Log(register + " is now " + reg[register]);
                        }
                    }
                }

                else if (instruction == "rcv")
                {
                    if (isNumber && value != 0)
                    {
                        return sound;

                    }
                    else if ((long)reg[register] != 0)
                    {
                        return sound;
                    }
                }

                else if (instruction == "jgz")
                {
                    if (long.TryParse(register, out long n))
                    {
                        if (n > 0)
                        {
                            if (isNumber)
                                i += (int)value;
                            else
                                i += (int)reg[source];

                            i--;
                        }
                    }


                    else
                    {
                        if ((long)reg[register] > 0)
                        {
                            if (isNumber)
                                i += (int)value;
                            else
                                i += (int)reg[source];

                            i--;
                        }
                    }
                }

                if (log)
                    IO.LogDivider();
            }

            if (log)
                IO.WriteLogToFile(false, false);

            return -1;
        }

        
    }
}
