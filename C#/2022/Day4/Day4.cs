using AoC.IO;

Input.TestMode = false;
var input = Input.Rows;

var part1 = 0;
var part2 = 0;

foreach(var row in input)
{
    var numbers = row.Replace(',', '-').Split('-').Select(s => int.Parse(s)).ToList();

    if ((numbers[0] <= numbers[2] && numbers[1] >= numbers[3]) || (numbers[0] >= numbers[2] && numbers[1] <= numbers[3]))
        part1++;

    if ((numbers[0] >= numbers[2] && numbers[0] <= numbers[3]) || (numbers[2] >= numbers[0] && numbers[2] <= numbers[1]))
        part2++;


}
Output.Answer(part1);
Output.Answer(part2);