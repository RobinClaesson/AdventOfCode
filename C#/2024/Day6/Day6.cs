using AoC.IO;
using System.Numerics;

Input.TestMode = false;

var input = Input.Rows;

var guardY = input.FindIndex(r => r.Contains('^'));
var guardX = input[guardY].IndexOf('^');

var guardPos = new Vector2(guardX, guardY);

var currentDirection = 0;
Vector2[] directions = [new Vector2(0, -1), new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0)];
var visited = new HashSet<Vector2> { guardPos };

var nextPos = guardPos;
do
{

    if (input[(int)nextPos.Y][(int)nextPos.X] == '#')
    {
        currentDirection = (currentDirection + 1) % directions.Length;
    }
    else
    {
        guardPos = nextPos;
        visited.Add(guardPos);
    }

    nextPos = guardPos + directions[currentDirection];
} while (nextPos.Y >= 0 && nextPos.Y < input.Count &&
       nextPos.X >= 0 && nextPos.X < input[0].Length);

Output.Answer(visited.Count);


//Naive solution but it works in ~1 min
var part2 = 0;
var total = input.Count * input[0].Length;
for (int y = 0; y < input.Count; y++)
{
    for (int x = 0; x < input[y].Length; x++)
    {
        if (input[y][x] == '#')
            continue;

        Console.CursorLeft = 0;
        var progress = y * input[y].Length + x;
        if (progress % 100 == 0)
            Console.Write($"Part2 progress: {progress}/{total}      ");


        guardPos = new Vector2(guardX, guardY);

        var m = GetInputCopy();
        m[y][x] = '#';
        if (IsCycle(m, guardPos))
            part2++;
    }
}
Console.WriteLine();
Output.Answer(part2);

static bool IsCycle(List<char[]> map, Vector2 pos)
{
    var visited = new HashSet<(Vector2 Pos, int Direction)>();
    int currentDirection = 0;
    Vector2[] directions = [new Vector2(0, -1), new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0)];

    var nextPos = pos;
    do
    {
        if (map[(int)nextPos.Y][(int)nextPos.X] == '#')
        {
            currentDirection = (currentDirection + 1) % directions.Length;
        }
        else
        {
            pos = nextPos;

            if (visited.Contains((pos, currentDirection)))
                return true;

            visited.Add((pos, currentDirection));
        }

        nextPos = pos + directions[currentDirection];
    } while (nextPos.Y >= 0 && nextPos.Y < map.Count &&
           nextPos.X >= 0 && nextPos.X < map[0].Length);

    return false;
}

List<char[]> GetInputCopy()
    => Input.Rows.Select(r => r.ToCharArray()).ToList();