using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;


namespace Day_16
{  
    class Program
    {
        static void Main(string[] args)
        {
            
            Part1();

            //Part 2
            List<string> input = IO.InputRows;

            Sue giver = new Sue(true);
            Sue unknown;

            int i = 0;
            do
            {
                unknown = new Sue(false);

                input[i] = input[i].Substring(input[i].IndexOf(":") + 1).Replace(" ", String.Empty);


                string[] variables = input[i].Split(',');

                foreach (string variable in variables)
                    unknown.SetItemCount(variable.Split(':')[0], variable.Split(':')[1]);

                i++;
            } while (!giver.Matches2(unknown));

            IO.Output(i, true);
            Console.ReadKey();
        }

        private static void Part1()
        {
            Console.WriteLine("Part 1");
            List<string> input = IO.InputRows;

            Sue giver = new Sue(true);
            Sue unknown;

            int i = 0;
            do
            {
                unknown = new Sue(false);

                input[i] = input[i].Substring(input[i].IndexOf(":") + 1).Replace(" ", String.Empty);


                string[] variables = input[i].Split(',');

                foreach (string variable in variables)
                    unknown.SetItemCount(variable.Split(':')[0], variable.Split(':')[1]);

                i++;
            } while (!giver.Matches(unknown));

            IO.Output(i);
        }
    }
}
