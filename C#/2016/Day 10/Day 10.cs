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


            //Loads the instructions for the bots
            for (int i = 0; i < input.Count; i++)
            {
                string action = input[i][0];

                if (action == "value")
                {
                    int value = int.Parse(input[i][1]);
                    int botID = int.Parse(input[i].Last());

                    AddValueToBots(ref bots, botID, value);
                }

                else if (action == "bot")
                {
                    int botID = int.Parse(input[i][1]);

                    AddBots(ref bots, botID);

                    bots[botID].LowOutputPlace = input[i][5] + " " + input[i][6];
                    bots[botID].HighOutputPlace = input[i][10] + " " + input[i][11];
                }


            }

            //makes the movements
            bool movedBot;
            do
            {
                movedBot = false;

                foreach (Bot bot in bots)
                {
                    if (bot.CanMove && !bot.HasMoved)
                    {
                        //Outputs low
                        int targetID = int.Parse(bot.LowOutputPlace.Split(' ').Last());
                        if (bot.LowOutputPlace.Contains("bot"))
                            AddValueToBots(ref bots, targetID, bot.LowOutput);


                        else
                            AddToOutput(ref output, targetID, bot.LowOutput);


                        //Outputs high
                        targetID = int.Parse(bot.HighOutputPlace.Split(' ').Last());
                        if (bot.HighOutputPlace.Contains("bot"))
                            AddValueToBots(ref bots, targetID, bot.HighOutput);


                        else
                            AddToOutput(ref output, targetID, bot.HighOutput);

                        movedBot = true;
                        bot.HasMoved = true;
                    }
                }


            } while (movedBot);

            int part1 = -1;
            for(int i = 0; i < bots.Count; i++)
                if(bots[i].HasBothChips(61,17))
                {
                    part1 = i;
                    break;
                }


            IO.Output(part1);
            IO.Output(output[0] * output[1] * output[2]);
            Console.ReadKey();
        }

        private static void AddValueToBots(ref List<Bot> bots, int id, int value)
        {
            AddBots(ref bots, id);

            bots[id].Input(value);
        }
        private static void AddBots(ref List<Bot> bots, int id)
        {
            while (bots.Count - 1 < id)
                bots.Add(new Bot());

        }
        private static void AddToOutput(ref List<int> output, int id, int value)
        {
            while (output.Count - 1 < id)
                output.Add(-1);

            output[id] = value;
        }
    }
}
