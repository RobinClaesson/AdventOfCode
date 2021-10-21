using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            string currentState = input[0].Substring(input[0].LastIndexOf(" ") + 1);
            input.RemoveRange(0, 2);

            Dictionary<string, char> rules = new Dictionary<string, char>();

            foreach (string row in input)
            {
                rules[row.Substring(0, 5)] = row.Last();
            }

            //Console.WriteLine("0: " + currentState);

            int startIndex = 0;
            //Growth generations
            for (int generation = 1; generation <= 20; generation++)
            {
                string nextState = "";

                //Check first two incase we need to add empty pots to the begining
                nextState += NextGen(".." + currentState.Substring(0, 3), rules);
                nextState += NextGen("." + currentState.Substring(0, 4), rules);

                if (nextState.Contains("#"))
                {
                    nextState = ".." + nextState;
                    startIndex -= 2;
                }

                for (int i = 2; i < currentState.Length - 2; i++)
                    nextState += NextGen(currentState.Substring(i - 2, 5), rules);

                //Check last two incase we need to add empty pots to the begining
                //string sub = currentState.Substring(currentState.Length - 3) + "..";
                nextState += NextGen(currentState.Substring(currentState.Length - 4) + ".", rules);
                nextState += NextGen(currentState.Substring(currentState.Length - 3) + "..", rules);

                string sub = nextState.Substring(nextState.Length - 2);
                if (nextState.Substring(nextState.Length - 2).Contains("#"))
                    nextState += "..";

                currentState = nextState;
                //Console.WriteLine(generation + ": " + currentState);
            }

            //Sum number on pots
            int sum = 0;
            for(int i = 0; i < currentState.Length; i++)
            {
                if (currentState[i] == '#')
                    sum += startIndex + i;
            }

            

            IO.Output(sum);
            Console.ReadKey();
        }

        public static char NextGen(string plants, Dictionary<string, char> rules)
        {
            if (rules.Keys.Contains(plants))
                return rules[plants];


            return '.';
        }
    }
}
