using System.Numerics;
using AoC.IO;

var input = Input.Split(',');
Output.Answer(StepsToLast(input));
Output.Answer(StepsToFirstRevist(input));

float StepsToLast(List<string> input)
{
    Direction direction = Direction.North;
    Vector2 pos = new Vector2(0, 0);

    foreach (string instruction in input)
    {

        if (instruction != "")
        {

            int steps = 0;


            if (instruction.Contains("R"))
            {
                steps = int.Parse(instruction.Substring(instruction.IndexOf("R") + 1));
                direction = Turn("R", direction);

            }
            else
            {
                steps = int.Parse(instruction.Substring(instruction.IndexOf("L") + 1));
                direction = Turn("L", direction);

            }

            pos = Move(pos, steps, direction);

        }
    }

    return Math.Abs(pos.X) + Math.Abs(pos.Y);
}

float StepsToFirstRevist(List<string> input)
{
    List<Vector2> visited = new List<Vector2>();

    Direction direction = Direction.North;
    Vector2 pos = new Vector2(0, 0);

    foreach (string instruction in input)
    {

        if (instruction != "")
        {
            int steps = 0;


            if (instruction.Contains("R"))
            {
                steps = int.Parse(instruction.Substring(instruction.IndexOf("R") + 1));


                direction = Turn("R", direction);
            }
            else
            {
                steps = int.Parse(instruction.Substring(instruction.IndexOf("L") + 1));
                direction = Turn("L", direction);
            }


            for (int i = 0; i < steps; i++)
            {
                pos = Step(pos, direction);

                foreach (Vector2 place in visited)
                {
                    if (place.X == pos.X && place.Y == pos.Y)
                    {
                        return Math.Abs(pos.X) + Math.Abs(pos.Y);
                    }
                }

                visited.Add(pos);
            }
        }
    }

    return -1;
}

static Direction Turn(string dir, Direction current)
{
    if (dir == "R")
    {
        current += 1;

        if (current > Direction.West)
            current = Direction.North;
    }

    else
    {
        current--;

        if (current < Direction.North)
            current = Direction.West;
    }

    return current;
}

static Vector2 Move(Vector2 startPos, int steps, Direction direction)
{
    switch (direction)
    {
        case Direction.North:
            startPos.Y -= steps;

            break;

        case Direction.South:
            startPos.Y += steps;
            break;

        case Direction.East:
            startPos.X += steps;
            break;

        case Direction.West:
            startPos.X -= steps;
            break;
    }

    return startPos;
}

Vector2 Step(Vector2 startPos, Direction direction)
{
    return Move(startPos, 1, direction);
}

enum Direction { North, East, South, West }