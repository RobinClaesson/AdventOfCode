using AoC.IO;

Input.TestMode = false;

var input = Input.RowsAsInt;

var part1 = input.Select(x => x/3 - 2).Sum();
Output.Answer(part1);

var part2 = input.Select(x =>
{
    var total = 0;
    while (x > 0)
    {
        x = x/3 - 2;
        if (x > 0) 
            total += x;
    }
    return total;
}).Sum();
Output.Answer(part2);
