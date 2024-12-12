using AoC.IO;
using AoC.Tools;
using System.Numerics;

Input.TestMode = false;

var input = Input.Rows;

var regions = new List<HashSet<Vector2>>();
var seen = new List<Vector2>();

//Find all regions
Console.WriteLine("Finding regions");
for (int y = 0; y < input.Count; y++)
{
    for (int x = 0; x < input[y].Length; x++)
    {
        var startPos = new Vector2(x, y);
        var c = input[y][x];
        if (!seen.Contains(startPos) && c != ' ') //Space used for debugging
        {

            var region = new HashSet<Vector2>();
            var toAdd = new Queue<Vector2>();
            toAdd.Enqueue(startPos);

            while (toAdd.Count > 0)
            {
                var current = toAdd.Dequeue();
                region.Add(current);
                seen.Add(current);

                //Add all neighbours that are the same character
                var adj = SquareGrid.FourDirAdjecentPoints(current)
                            .Where(p => !seen.Contains(p))
                            .Where(p => p.X >= 0 && p.X < input[0].Length && p.Y >= 0 && p.Y < input.Count)
                            .Where(p => input[(int)p.Y][(int)p.X] == c)
                            .ToList();

                foreach (var a in adj)
                {
                    seen.Add(a);
                    toAdd.Enqueue(a);
                }

            }
            regions.Add(region);
        }
    }
}
Console.WriteLine("Regions found");

var part1 = regions.Sum(r => r.Count * GetPerimeter(r));
Output.Answer(part1);
int GetPerimeter(IEnumerable<Vector2> region)
    => region.Sum(p => SquareGrid.FourDirAdjecentPoints(p)
                        .Count(p => !region.Contains(p)));
