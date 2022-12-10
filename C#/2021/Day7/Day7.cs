using AoC.IO;

var input = Input.SplitAsInt(',');

input.Sort();

int part1 = int.MaxValue;
int part2 = int.MaxValue;
for (int i = 0; i < input.Count; i++)
{
    //Part 1
    int sum = 0;
    for (int j = 0; j < input.Count; j++)
        sum += Math.Abs(input[i] - input[j]);

    if (sum < part1)
        part1 = sum;

    //Part 2
    sum = 0;
    for (int j = 0; j < input.Count; j++)
    {

        int diff = Math.Abs(input[i] - input[j]);

        sum += (diff * (diff + 1)) / 2; //Aritmetic Sum
    }
    if (sum < part2)
        part2 = sum;
}

Output.Answer(part1);
Output.Answer(part2);