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

var part1 = regions.Sum(r => r.Count * GetPerimeterLength(r));
Output.Answer(part1);

// The number of sides are the same as the number of corners
var part2 = regions.Sum(r => r.Count * GetCornerCount(r));
Output.Answer(part2);



int GetPerimeterLength(IEnumerable<Vector2> region)
    => region.Sum(p => SquareGrid.FourDirAdjecentPoints(p)
                        .Count(p => !region.Contains(p)));

IEnumerable<Vector2> GetPerimiterPoints(IEnumerable<Vector2> region)
    => region.Where(p => SquareGrid.AdjacentPoints(p)   //Not 4 way because we want to include concave corners
                        .Any(p => !region.Contains(p)));

int GetCornerCount(IEnumerable<Vector2> region)
{
    //Only needs to check perimeter points
    var perimiter = GetPerimiterPoints(region).ToList();
    var corners = 0;

    foreach (var p in perimiter)
    {
        //If the two adjacent points are not the same character, it is a convex corner
        //If the two adjacent points are the same character and the diagonal is NOT the same character, it is a concave corner
        //Otherwise it's not a corner
        //We check all 4 directions  a single point can be multiple corners
        var up = new Vector2(p.X, p.Y - 1);
        var upRight = new Vector2(p.X + 1, p.Y - 1);
        var right = new Vector2(p.X + 1, p.Y);
        var downRight = new Vector2(p.X + 1, p.Y + 1);
        var down = new Vector2(p.X, p.Y + 1);
        var downLeft = new Vector2(p.X - 1, p.Y + 1);
        var left = new Vector2(p.X - 1, p.Y);
        var upLeft = new Vector2(p.X - 1, p.Y - 1);

        //Up right convex
        if (!region.Contains(up) && !region.Contains(right))
            corners++;
        //Up right concave
        else if (region.Contains(up) && region.Contains(right) && !region.Contains(upRight))
            corners++;

        //Right down convex
        if (!region.Contains(right) && !region.Contains(down))
            corners++;
        //Right down concave
        else if (region.Contains(right) && region.Contains(down) && !region.Contains(downRight))
            corners++;

        //Down left convex
        if (!region.Contains(down) && !region.Contains(left))
            corners++;
        //Down left concave
        else if (region.Contains(down) && region.Contains(left) && !region.Contains(downLeft))
            corners++;

        //Left up convex
        if (!region.Contains(left) && !region.Contains(up))
            corners++;
        //Left up concave
        else if (region.Contains(left) && region.Contains(up) && !region.Contains(upLeft))
            corners++;
    }

    return corners;
}

void PrintRegion(IEnumerable<Vector2> region)
{
    var minX = (int)region.Min(p => p.X);
    var minY = (int)region.Min(p => p.Y);
    var maxX = (int)region.Max(p => p.X);
    var maxY = (int)region.Max(p => p.Y);
    for (int y = minY; y <= maxY; y++)
    {
        for (int x = minX; x <= maxX; x++)
        {
            if (region.Contains(new Vector2(x, y)))
                Console.Write(input[y][x]);
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
}