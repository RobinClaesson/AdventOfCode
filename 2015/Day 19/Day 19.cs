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
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            string inputMed = input[input.Count - 1];
            //Removes the medicine and the empty road before it form the list
            input.RemoveAt(input.Count - 1);
            input.RemoveAt(input.Count - 1);

            //Part 1
            IO.Output(NewMedicines(input, inputMed).Count);


            //Part 2
            OldPart2(input, inputMed);
            Console.ReadKey();
        }

        private static void OldPart2(List<string> input, string inputMed)
        {
            List<string> medicines = new List<string>();
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
    }


}

