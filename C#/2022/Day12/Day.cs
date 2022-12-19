using AoC.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;


Input.TestMode = false;
var input = Input.Rows.Select(r => r.Select(c => CharToInt(c)).ToList()).ToList();

var startY = input.FindIndex(r => r.Contains(0));
var startX = input[startY].FindIndex(i => i == 0);

var endY = input.FindIndex(r => r.Contains(CharToInt('E')));
var endX = input[endY].FindIndex(i => i == CharToInt('E'));

//Console.WriteLine($"S=({startX}, {startY}) E=({endX},{endY})");

var dist = new List<List<int>>();
var edgeTo = new List<List<Point>>();
for (int y = 0; y < input.Count; y++)
{
    dist.Add(new List<int>());
    edgeTo.Add(new List<Point>());
    for (int x = 0; x < input[y].Count; x++)
    {
        dist[y].Add(x == startX && y == startY ? 0 : -1);
        edgeTo[y].Add(x == startX && y == startY ? Point.Empty : new Point(-1, -1));
    }
}


var bfsQ = new Queue<Point>();
bfsQ.Enqueue(new Point(startX, startY));

while (bfsQ.Count > 0)
{
    var p = bfsQ.Dequeue();

    var adj = new Point[] { new Point(p.X + 1, p.Y), new Point(p.X, p.Y + 1),
                            new Point(p.X - 1, p.Y), new Point(p.X, p.Y - 1) };

    foreach (var a in adj)
    {
        if (a.Y >= 0 && a.Y < input.Count && a.X >= 0 && a.X < input[a.Y].Count)
        {
            if (dist[a.Y][a.X] == -1)
            {

                if (input[p.Y][p.X] >= input[a.Y][a.X] - 1)
                {
                    dist[a.Y][a.X] = dist[p.Y][p.X] + 1;
                    edgeTo[a.Y][a.X] = p;
                    bfsQ.Enqueue(a);
                }
            }
        }
    }
}

Output.Answer(dist[endY][endX]);

//PrintList(dist);

OpenInNotepad(dist, "dist.txt", '\t');
OpenInNotepad(input, "inputInt.txt", '\t');

var inputChar = Input.Rows.Select(r => r.ToList()).ToList();

Point curr = new Point(endX, endY);


int count = 0;
while (dist[curr.Y][curr.X] != 0)
{
    inputChar[curr.Y][curr.X] -= (char)32;
    curr = edgeTo[curr.Y][curr.X];

}

for (int y = 0; y < input.Count; y++)
    for (int x = 0; x < input[y].Count; x++)
        if (inputChar[y][x] >= 'a')
            dist[y][x] = 0;

OpenInNotepad(inputChar, "path.txt", ' ');
OpenInNotepad(dist, "pathDist.txt", '\t');
Console.WriteLine(count);


void PrintList(List<List<int>> list)
{
    for (int y = 0; y < list.Count; y++)
    {
        for (int x = 0; x < list[y].Count; x++)
            Console.Write($"{list[y][x]}\t");

        Console.WriteLine();
    }
}

void OpenInNotepad<T>(List<List<T>> list, string name, char separator)
{
    var writer = new StreamWriter(name);
    for (int y = 0; y < list.Count; y++)
    {
        for (int x = 0; x < list[y].Count; x++)
            writer.Write($"{list[y][x]}{separator}");

        writer.WriteLine();
    }
    writer.Close();
    //Process.Start("notepad.exe", name);
}

int CharToInt(char c)
{
    if (c == 'S')
        return 0;
    else if (c == 'E')
        return CharToInt('z') + 1;

    return c - 'a' + 1;
}
