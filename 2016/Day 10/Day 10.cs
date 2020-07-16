using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted(' ');
            List<int> output = new List<int>();
            List<Bot> bots = new List<Bot>();

            while (input.Count > 0)
                for (int i = 0; i < input.Count; i++)
                {
                    string action = input[i][0];

                    if (action == "value")
                    {
                        int value = int.Parse(input[i][1]);
                        int botID = int.Parse(input[i].Last());

                        while (bots.Count - 1 < botID)
                            bots.Add(new Bot());

                        bots[botID].Input(value);

                        input.RemoveAt(i);
                        i--;
                    }

                    else if (action == "bot")
                    {

                    }


                }


            Console.ReadKey();
        }
    }
}
