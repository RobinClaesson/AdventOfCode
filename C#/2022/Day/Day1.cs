using AoC.IO;

var input = Input.Rows;
input.Add(string.Empty); //Ad extra empty row to catch the if statement for the last elf

var elves = new List<int>();
var current = 0;

foreach (string row in input)
{
    if (row == string.Empty)
    {
        elves.Add(current);
        current = 0;
    }
    else
        current += int.Parse(row);
}
elves = elves.OrderByDescending(e => e).ToList();

Output.Answer(elves[0]);
Output.Answer(elves[0] + elves[1] + elves[2]);