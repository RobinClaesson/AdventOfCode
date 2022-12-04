using AoC.IO;

Input.TestMode = false;
var input = Input.Rows;

var part1 = 0;
foreach (var row in input)
{
    var first = row.Substring(0, row.Length / 2);
    var second = row.Substring(row.Length / 2);

    var dupe = first.Intersect(second).FirstOrDefault();

    if (dupe >= 'a' && dupe <= 'z')
        part1 += 1 + dupe - 'a';
    else
        part1 += 27 + dupe - 'A';
}

Output.Answer(part1);

var part2 = 0;
for (int i = 0; i < input.Count; i += 3)
{
    var dupe = input[i].Intersect(input[i + 1]).Intersect(input[i + 2]).FirstOrDefault();

    if (dupe >= 'a' && dupe <= 'z')
        part2 += 1 + dupe - 'a';
    else
        part2 += 27 + dupe - 'A';
}

Output.Answer(part2);