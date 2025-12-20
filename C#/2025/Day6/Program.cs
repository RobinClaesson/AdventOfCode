using AoC.IO;
using AoC.Extensions;

Input.TestMode = false;
var input = Input.Rows;

var operators = input
    .Last()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

var numberRows = input
    .Take(input.Count - 1)
    .ToList();

var part1Numbers = numberRows
    .Select(row => row.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList())
    .ToList();

var part1 = operators
    .Select(GetPart1Column)
    .Sum(column => column.Result);

Output.Answer(part1);

var columnStarts = input
    .Last()
    .Append('X')
    .Select((c, i) => (Operator: c, Index: i))
    .Where(c => c.Operator != ' ')
    .Select(c => c.Index)
    .ToList();

var part2 = 0L;
for (var i = 0; i < columnStarts.Count - 1; i++)
{
    try
    {
        var lenngth = columnStarts[i + 1] - columnStarts[i] - 1;
        var column = numberRows
            .Select(row => row.Substring(columnStarts[i], lenngth))
            .ToList();

        var numbers = new List<long>();
        for (var j = 0; j < column[0].Length; j++)
        {
            var characters = column.Select(row => row[j]).ToList();
            numbers.Add(long.Parse(string.Join(string.Empty, characters)));
        }


        if (operators[i] == "+")
            part2 += numbers.Sum();
        else
            part2 += numbers.Multiply();
    }
    catch (Exception e)
    {
    }
}

Output.Answer(part2);
return;

Column GetPart1Column(string op, int index) => new(op, part1Numbers.Select(n => n[index]));

internal record Column(string Operator, IEnumerable<long> Numbers)
{
    public long Result => Operator == "+" ? Numbers.Sum() : Numbers.Multiply();
}