using AoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted(' ');

            Hashtable registers = new Hashtable();
            int maxDuring = int.MinValue;
            foreach (string[] row in input)
            {
                //Adds the registers if it is the first time we see them
                if (!registers.ContainsKey(row[0]))
                    registers.Add(row[0], 0);

                if (!registers.ContainsKey(row[4]))
                    registers.Add(row[4], 0);

                int conditionValue = int.Parse(row[6]);

                bool condition = false;
                switch (row[5])
                {
                    case ">":
                        condition = (int)registers[row[4]] > conditionValue;
                        break;

                    case "<":
                        condition = (int)registers[row[4]] < conditionValue;
                        break;

                    case ">=":
                        condition = (int)registers[row[4]] >= conditionValue;
                        break;

                    case "<=":
                        condition = (int)registers[row[4]] <= conditionValue;
                        break;

                    case "==":
                        condition = (int)registers[row[4]] == conditionValue;
                        break;

                    case "!=":
                        condition = (int)registers[row[4]] != conditionValue;
                        break;
                }

                if (condition)
                {
                    if (row[1] == "inc")
                        registers[row[0]] = (int)registers[row[0]] + int.Parse(row[2]);

                    else
                        registers[row[0]] = (int)registers[row[0]] - int.Parse(row[2]);

                    if ((int)registers[row[0]] > maxDuring)
                        maxDuring = (int)registers[row[0]];
                }
            }

            int maxAfter = int.MinValue;
            foreach (object reg in registers.Values)
                if ((int)reg > maxAfter)
                    maxAfter = (int)reg;

            IO.Output(maxAfter);
            IO.Output(maxDuring);
            Console.ReadKey();
        }
    }
}
