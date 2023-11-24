using Day_10;
using AoC.IO;

List<string[]> input = Input.RowsSplitted(' ');
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
for (int i = 0; i < bots.Count; i++)
    if (bots[i].HasBothChips(61, 17))
    {
        part1 = i;
        break;
    }

Output.Answer(part1);
Output.Answer(output[0] * output[1] * output[2]);

void AddValueToBots(ref List<Bot> bots, int id, int value)
{
    AddBots(ref bots, id);

    bots[id].Input(value);
}
void AddBots(ref List<Bot> bots, int id)
{
    while (bots.Count - 1 < id)
        bots.Add(new Bot());

}
void AddToOutput(ref List<int> output, int id, int value)
{
    while (output.Count - 1 < id)
        output.Add(-1);

    output[id] = value;
}