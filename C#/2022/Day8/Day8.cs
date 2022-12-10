using AoC.IO;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks.Sources;

Input.TestMode = false;
var input = Input.IntGrid;

var visible = new List<Point>();

for (int y = 0; y < input.Count; y++)
{
    int highest = -1;
    for (int x = 0; x < input[y].Count; x++)
    {
        if (input[y][x] > highest)
        {
            visible.Add(new Point(x, y));
            highest = input[y][x];
        }
    }

    highest = -1;
    for (int x = input[y].Count - 1; x >= 0; x--)
    {
        if (input[y][x] > highest)
        {
            visible.Add(new Point(x, y));
            highest = input[y][x];
        }
    }
}

for (int x = 0; x < input[0].Count; x++)
{
    int highest = -1;
    for (int y = 0; y < input.Count; y++)
    {
        if (input[y][x] > highest)
        {
            visible.Add(new Point(x, y));
            highest = input[y][x];
        }
    }

    highest = -1;
    for (int y = input.Count - 1; y >= 0; y--)
    {
        if (input[y][x] > highest)
        {
            visible.Add(new Point(x, y));
            highest = input[y][x];
        }
    }
}

Output.Answer(visible.Distinct().Count());

int max = 0;
for (int y = 1; y < input.Count - 1; y++)
{
    for (int x = 1; x < input[y].Count - 1; x++)
    {
        var current = input[y][x];

        var l = input[y].GetRange(0, x).FindLastIndex(i => i >= current);
        if (l == -1)
            l = x;
        else
            l = x - l;

        var r = input[y].FindIndex(x + 1, i => i >= current);
        if (r == -1)
            r = input[y].Count - x - 1;
        else
            r = r - x;

        var collumn = input.Select(r => r[x]).ToList();

        var u = collumn.GetRange(0, y).FindLastIndex(i => i >= current);
        if (u == -1)
            u = y;
        else
            u = y - u;

        var d = collumn.FindIndex(y + 1, i => i >= current);
        if (d == -1)
            d = collumn.Count - y - 1;
        else
            d = d - y;


        var score = l * r * u * d;

        if (score > max)
            max = score;

    }
}

Output.Answer(max);
