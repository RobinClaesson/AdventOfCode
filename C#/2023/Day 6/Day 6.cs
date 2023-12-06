using AoC.IO;

Input.TestMode = false;
var all = Input.All;
var input = Input.Rows.Select(r => r.Split(':')[1].Trim().Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(s => int.Parse(s)).ToList()).ToList();

var part1 = 1;

for (int i = 0; i < input[0].Count; i++)
{
    var waysForRecord = 0;
    for (int j = 1; j <= input[0][i]; j++)
        if (j * (input[0][i] - j) > input[1][i])
            waysForRecord++;

    part1 *= waysForRecord;
}
Output.Answer(part1);

var timeString = string.Empty;
var distString = string.Empty;
for (int i = 0; i < input[0].Count; i++)
{
    timeString += $"{input[0][i]}";
    distString += $"{input[1][i]}";
}
var time = int.Parse(timeString);
var dist = long.Parse(distString);

long start = 0;
long end = 0;
for (long i = 0; i < time; i++)
{
    if (i * (time - i) > dist)
    {
        start = i;
        break;
    }
}

for (long i = time; i > 0; i--)
{
    if (i * (time - i) > dist)
    {
        end = i;
        break;
    }
}

Output.Answer(end - start + 1);
