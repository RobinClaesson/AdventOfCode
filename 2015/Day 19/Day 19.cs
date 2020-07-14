using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_19
{
    class Program
    {
        static void Main()
        {
            List<string> input = IO.InputRows;

            string medicine = input[input.Count - 1];
            //Removes the medicine and the empty road before it form the list
            input.RemoveAt(input.Count - 1);
            input.RemoveAt(input.Count - 1);

            //Part 1
            IO.Output(NewMedicines(input, medicine).Count);


            //Part 2
            //https://www.reddit.com/r/adventofcode/comments/3xflz8/day_19_solutions/cy4p1td?utm_source=share&utm_medium=web2x

            medicine = medicine.Replace("Rn", "(");
            medicine = medicine.Replace("Y", ",");
            medicine = medicine.Replace("Ar", ")");

            List<string> tokens = new List<string>();

            foreach (string row in input)
                if (!tokens.Contains(row.Split(' ')[0]))
                    tokens.Add(row.Split(' ')[0]);

            foreach (string t in tokens)
                medicine = medicine.Replace(t, "T");

            int totalTokens = medicine.Length;

            int brackets = 0, commas = 0;
            foreach (char c in medicine)
            {
                if (c == '(' || c == ')')
                    brackets++;

                else if (c == ',')
                    commas++;
            }

            
            IO.Output(totalTokens - brackets - (2 * commas)-1);

            Console.ReadKey();
        }


        private static List<string> NewMedicines(List<string> input, string startMed)
        {
            List<string> newMedicines = new List<string>();

            foreach (string row in input)
            {
                string[] words = row.Split(' ');

                string find = words[0], replace = words[2];

                List<int> matches = new List<int>();

                for (int i = 0; i <= startMed.Length - find.Length; i++)
                {
                    if (startMed.Substring(i, find.Length) == find)
                        matches.Add(i);
                }

                foreach (int i in matches)
                {
                    string newMed = startMed.Substring(0, i) + replace + startMed.Substring(i + find.Length);

                    if (!newMedicines.Contains(newMed))
                        newMedicines.Add(newMed);
                }

            }

            return newMedicines;
        }

        


        //This in theory works and does so for both examples. But it scales really bad and is now usable
#pragma warning disable IDE0051 // Remove unused private members
        private static void OldPart2(List<string> input, string inputMed)
#pragma warning restore IDE0051 // Remove unused private members
        {
#pragma warning disable IDE0028 // Simplify collection initialization
            List<string> medicines = new List<string>();
#pragma warning restore IDE0028 // Simplify collection initialization
            medicines.Add("e");

            List<string> seenMeds = new List<string>();

            int steps = 0;
            do
            {
                seenMeds.AddRange(medicines);

                List<string> newMeds = new List<string>();

                foreach (string med in medicines)
                {
                    List<string> extenstions = NewMedicines(input, med);

                    foreach (string ext in extenstions)
                    {
                        if (!newMeds.Contains(ext) && !seenMeds.Contains(ext))
                            newMeds.Add(ext);
                    }
                }

                medicines.Clear();
                medicines.AddRange(newMeds);
                steps++;
            } while (!medicines.Contains(inputMed));


            IO.Output(steps);
        }
    }


}

