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

            List<string> seenStates = new List<string>();
            seenStates.Add(CleanState(currentState));
            //Console.WriteLine("0: " + currentState);

            long startIndex = 0;
            //Growth generations
            long generation = 1;
            while (generation <= 20)
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
                nextState += NextGen(currentState.Substring(currentState.Length - 4) + ".", rules);
                nextState += NextGen(currentState.Substring(currentState.Length - 3) + "..", rules);

                string sub = nextState.Substring(nextState.Length - 2);
                if (nextState.Substring(nextState.Length - 2).Contains("#"))
                    nextState += "..";

                currentState = nextState;
                seenStates.Add(CleanState(currentState));

                generation++;
            }

            //Sum number on pots
            long sum = 0;
            for (int i = 0; i < currentState.Length; i++)
            {
                if (currentState[i] == '#')
                    sum += startIndex + i;
            }
            IO.Output(sum);

            //Part 2
            //By testing i found that after a certain number of repititions the plants just move to the right
            while (generation <= 50000000000)
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
                nextState += NextGen(currentState.Substring(currentState.Length - 4) + ".", rules);
                nextState += NextGen(currentState.Substring(currentState.Length - 3) + "..", rules);

                string sub = nextState.Substring(nextState.Length - 2);
                if (nextState.Substring(nextState.Length - 2).Contains("#"))
                    nextState += "..";

                currentState = nextState;

                string cleanCurrent = CleanState(currentState);

                if (!seenStates.Contains(cleanCurrent))
                {
                    seenStates.Add(CleanState(currentState));
                }

                //The plants only move one step to the right from here on
                //So we can just move the start index the remaindings generations and stop
                else
                {
                    //Debug values used to figure out what was going on
                    //int index = seenStates.IndexOf(cleanCurrent);
                    //int firstPlant = currentState.IndexOf("#");
                    //int lastPlant = currentState.LastIndexOf("#");
                    //int diff = lastPlant - firstPlant;

                    startIndex += 50000000000 - generation;
                    break;
                }

                generation++;
            }

            //Sum number on pots
            sum = 0;
            for (int i = 0; i < currentState.Length; i++)
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


        public static string CleanState(string state)
        {
            int first = state.IndexOf("#");
            int last = state.LastIndexOf("#");
            return state.Substring(first, last - first + 1);
        }
    }
}
