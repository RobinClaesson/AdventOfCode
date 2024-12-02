using AoC.IO;

Input.TestMode = false;

var input = Input.RowsSplittedAsInt(' ');

var part1 = 0;

foreach (var row in input)
{
    var incOrder = row.Order().ToList();
    var decOrder = row.OrderDescending().ToList();

    if (row.SequenceEqual(incOrder) || row.SequenceEqual(decOrder))
    {
        var diffs = row.Skip(1).Select((x, i) => Math.Abs(x - row[i])).ToList();
        if (diffs.All(d => d <= 3 && d > 0))
            part1++;
    }
}
Output.Answer(part1);

var part2 = 0;
foreach (var row in input)
{
    var safe = false;
    for (int i = 0; i < row.Length; i++)
    {
        var modified = new List<int>(row);
        modified.RemoveAt(i);
        var incOrder = modified.Order().ToList();
        var decOrder = modified.OrderDescending().ToList();

        if (modified.SequenceEqual(incOrder) || modified.SequenceEqual(decOrder))
        {
            var diffs = modified.Skip(1).Select((x, i) => Math.Abs(x - modified[i])).ToList();
            if (diffs.All(d => d <= 3 && d > 0))
            {
                safe = true;
                break;
            }
        }
    }
    if (safe)
        part2++;
}
Output.Answer(part2);