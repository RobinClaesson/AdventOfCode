using System.Numerics;
using AoC.IO;
using AoC.Tools;

Input.TestMode = false;
var input = Input.Rows.Select(s => s.ToCharArray()).ToArray();

var removedRolls = RemovePaperRolls();
Output.Answer(removedRolls);

int removed;
while ((removed = RemovePaperRolls()) != 0)
    removedRolls += removed;

Output.Answer(removedRolls);

int RemovePaperRolls()
{
    var found = new List<Vector2>();
    for (var y = 0; y < input.Length; y++)
    {
        for (var x = 0; x < input[y].Length; x++)
        {
            if (input[y][x] == '.')
                continue;

            var current = new Vector2(x, y);
            var adjacentRolls = SquareGrid.AdjacentPoints(current)
                .Where(p => p.Y >= 0 && p.Y < input.Length && p.X >= 0 && p.X < input[y].Length)
                .Count(p => input[(int)p.Y][(int)p.X] == '@');

            if (adjacentRolls < 4)
                found.Add(current);
        }
    }

    found.ForEach(p => input[(int)p.Y][(int)p.X] = '.');
    return found.Count;
}