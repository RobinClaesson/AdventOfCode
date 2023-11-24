using AoC.IO;

var input = Input.RowsSplittedAsInt(' ');

//Part 1
int valid = 0;
foreach (int[] sides in input)
{
    if (IsValid(sides))
    {
        valid++;
    }
}

Output.Answer(valid);

//Part 2
valid = 0;
for (int x = 0; x < input[0].Length; x++)
{
    for (int y = 0; y < input.Count; y += 3)
    {
        if (IsValid(new int[] { input[y][x], input[y + 1][x], input[y + 2][x] }))
            valid++;
    }
}
Output.Answer(valid);


bool IsValid(int[] sides)
{
    return (sides[0] + sides[1] > sides[2] && sides[2] + sides[1] > sides[0] && sides[0] + sides[2] > sides[1]);
}