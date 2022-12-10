using AoC.IO;
using System.Numerics;

Input.TestMode = false;
var input = Input.Rows;

var knots = new Vector2[] { Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero };

var minDist = Math.Sqrt(2.1);

var part1Visits = new List<Vector2> { Vector2.Zero };
var part2Visits = new List<Vector2> { Vector2.Zero };

foreach (var row in input)
{
    var info = row.Split(' ');
    var steps = int.Parse(info[1]);
    Vector2 movement = Vector2.Zero;

    switch (info[0])
    {
        case "R":
            movement.X = 1;
            break;
        case "L":
            movement.X = -1;
            break;
        case "U":
            movement.Y = 1;
            break;
        case "D":
            movement.Y = -1;
            break;
    }

    for (int i = 0; i < steps; i++)
    {
        knots[0] += movement;

        for (int j = 1; j < knots.Length; j++)
        {

            var diff = knots[j-1] - knots[j];
            if (diff.Length() > minDist)
            {
                knots[j] += new Vector2(Math.Sign(diff.X), Math.Sign(diff.Y));
            }
        }

        part1Visits.Add(knots[1]);
        part2Visits.Add(knots[9]);
    }
}

Output.Answer(part1Visits.Distinct().Count());
Output.Answer(part2Visits.Distinct().Count());