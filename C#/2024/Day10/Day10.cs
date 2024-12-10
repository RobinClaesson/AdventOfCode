using AoC.IO;
using AoC.Tools;
using System.Numerics;

Input.TestMode = false;

var input = Input.RowsAsIndividualInts;

var part1 = 0;
var part2 = 0;
for (int y = 0; y < input.Count; y++)
{
    for (int x = 0; x < input[y].Count; x++)
    {
        if (input[y][x] == 0)
        {
            part1 += Score(x, y, true);
            part2 += Score(x, y, false);
        }
    }
}

Output.Answer(part1);
Output.Answer(part2);


int Score(int startX, int startY, bool checkSeen)
{
    if (input[startY][startX] != 0)
        return 0;

    int score = 0;

    var queue = new Queue<Vector2>();
    var start = new Vector2(startX, startY);
    queue.Enqueue(start);
    var seen = new HashSet<Vector2> { start };

    while (queue.Count > 0)
    {
        var currentPos = queue.Dequeue();
        var currentVal = input[(int)currentPos.Y][(int)currentPos.X];

        var neighbours = SquareGrid.FourDirAdjecentPoints(currentPos).Where(p => !seen.Contains(p));
        foreach (var neighbour in neighbours)
        {
            if (neighbour.X < 0 || neighbour.X >= input[0].Count || neighbour.Y < 0 || neighbour.Y >= input.Count)
                continue;

            var neighbourVal = input[(int)neighbour.Y][(int)neighbour.X];

            if (neighbourVal == currentVal + 1)
            {
                if (checkSeen)
                    seen.Add(neighbour);

                if (neighbourVal == 9)
                    score++;
                else
                    queue.Enqueue(neighbour);
            }
        }
    }

    return score;
}