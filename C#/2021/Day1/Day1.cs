using AoC.IO;

List<int> input = Input.RowsAsInt;

int increased = 0;
for (int i = 1; i < input.Count; i++)
    if (input[i] > input[i - 1])
        increased++;

Output.Answer(increased);

increased = 0;
for (int i = 1; i < input.Count - 2; i++)
{
    int curr = input[i] + input[i + 1] + input[i + 2];
    int prev = input[i - 1] + input[i] + input[i + 1];

    if (prev < curr)
        increased++;
}

Output.Answer(increased);