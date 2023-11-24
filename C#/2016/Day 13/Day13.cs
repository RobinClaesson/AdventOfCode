using AoC.IO;
using AoC.Tools;
using System.Numerics;

Input.TestMode = false;

var input = Input.AllAsInt;

var startPos = new Vector2(1, 1);
var target = Input.TestMode ? new Vector2(7, 4) : new Vector2(31, 39);

Dictionary<Vector2, int> distances = new Dictionary<Vector2, int> { { startPos, 0 } };
var queue = new Queue<Vector2>();
queue.Enqueue(startPos);

while (!distances.Keys.Contains(target))
{
    var currentPos = queue.Dequeue();

    var neighbors = SquareGrid.FourDirAdjecentPoints(currentPos)
                            .Where(p => IsOpenSpace(p) && p.X >= 0 && p.Y >= 0)
                            .ToList();

    foreach (var neighbor in neighbors)
    {
        if (!distances.Keys.Contains(neighbor))
        {
            distances.Add(neighbor, distances[currentPos] + 1);
            queue.Enqueue(neighbor);
        }
    }
}

Output.Answer(distances[target]);

while (queue.Count > 0)
{
    var currentPos = queue.Dequeue();

    if (distances[currentPos] < 50)
    {

        var neighbors = SquareGrid.FourDirAdjecentPoints(currentPos)
                                .Where(p => IsOpenSpace(p) && p.X >= 0 && p.Y >= 0)
                                .ToList();

        foreach (var neighbor in neighbors)
        {
            if (!distances.Keys.Contains(neighbor))
            {
                distances.Add(neighbor, distances[currentPos] + 1);
                queue.Enqueue(neighbor);
            }
        }
    }
}

Output.Answer(distances.Count(d => d.Value <= 50));

bool IsOpenSpace(Vector2 pos)
{
    var number = pos.X * pos.X + 3 * pos.X + 2 * pos.X * pos.Y + pos.Y + pos.Y * pos.Y + input;
    var binary = Convert.ToString((int)number, 2);
    return binary.Count(c => c == '1') % 2 == 0;
}