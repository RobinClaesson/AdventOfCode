using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            //Part 1
            int twos = 0, threes = 0;

            foreach (string row in input)
            {
                List<char> chars = row.Distinct().ToList();
                bool gotTwo = false, gotThree = false;

                foreach (char c in chars)
                {
                    int count = row.Count(x => x == c); //Linq https://stackoverflow.com/questions/3866952/linq-count-character-apperance

                    if (count == 2)
                        gotTwo = true;
                    else if (count == 3)
                        gotThree = true;
                }

                if (gotTwo)
                    twos++;
                if (gotThree)
                    threes++;
            }

            IO.Output(twos * threes);


            //Part 2
            int i = 0, j = 0;
            bool found = false;

            string answ = ""; 
            while (!found && i < input.Count - 1)
            {

                j = i + 1;

                while (!found && j < input.Count)
                {
                    int diff = 0;
                    answ = "";

                    for (int k = 0; k < input[i].Length; k++)
                    {
                        if (input[i][k] != input[j][k])
                        {
                            diff++;

                            if (diff > 1)
                                break;
                        }

                        else
                            answ += input[i][k];


                    }

                    if (diff == 1) 
                        found = true;

                    if (!found)
                        j++;
                }

                if (!found)
                    i++;
            }
            IO.Output(answ);
            Console.ReadKey();
        }
    }
}
