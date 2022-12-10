using AoC.IO;

var input = Input.RowsSplitted(' ');

int x = 0, y = 0, aim = 0, y2 = 0;

foreach (string[] move in input)
{
    int steps = int.Parse(move[1]);

    if (move[0] == "down")
    {
        y += steps;
        aim += steps;
    }
    else if (move[0] == "up")
    {
        y -= steps;
        aim -= steps;
    }
    else if (move[0] == "forward")
    {
        x += steps;
        y2 += aim * steps;
    }
}


Output.Answer(x * y);
Output.Answer(x * y2);
