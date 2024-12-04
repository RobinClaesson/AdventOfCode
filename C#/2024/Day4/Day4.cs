using AoC.IO;

Input.TestMode = false;

var input = Input.Rows;

int part1 = 0;
int part2 = 0;
for (int y = 0; y < input.Count; y++)
{
    for (int x = 0; x < input[y].Length; x++)
    {
        if (input[y][x] == 'X')
            part1 += WordsFromPos(input, x, y).Count(w => w == "XMAS");

        if (input[y][x] == 'A' && HasXMas(input, x, y))
            part2++;
    }
}
Output.Answer(part1);
Output.Answer(part2);


List<string> WordsFromPos(List<string> input, int x, int y)
{
    var words = new List<string>();

    // Horizontal right
    var w = "";
    for (int i = 0; i < 4 && x + i < input[y].Length; i++)
    {
        w += input[y][x + i];
    }
    words.Add(w);

    // Horizontal left
    w = "";
    for (int i = 0; i < 4 && x - i >= 0; i++)
    {
        w += input[y][x - i];
    }
    words.Add(w);

    // Vertical down
    w = "";
    for (int i = 0; i < 4 && y + i < input.Count; i++)
    {
        w += input[y + i][x];
    }
    words.Add(w);

    // Vertical up
    w = "";
    for (int i = 0; i < 4 && y - i >= 0; i++)
    {
        w += input[y - i][x];
    }
    words.Add(w);

    // Diagonal down right
    w = "";
    for (int i = 0; i < 4 && x + i < input[y].Length && y + i < input.Count; i++)
    {
        w += input[y + i][x + i];
    }
    words.Add(w);

    // Diagonal down left
    w = "";
    for (int i = 0; i < 4 && x - i >= 0 && y + i < input.Count; i++)
    {
        w += input[y + i][x - i];
    }
    words.Add(w);

    // Diagonal up right
    w = "";
    for (int i = 0; i < 4 && x + i < input[y].Length && y - i >= 0; i++)
    {
        w += input[y - i][x + i];
    }
    words.Add(w);

    // Diagonal up left
    w = "";
    for (int i = 0; i < 4 && x - i >= 0 && y - i >= 0; i++)
    {
        w += input[y - i][x - i];
    }
    words.Add(w);


    return words;
}

bool HasXMas(List<string> input, int x, int y)
{
    if (x == 0 || x == input[y].Length - 1 || y == 0 || y == input.Count - 1)
        return false;

    var topLeftDownRight = (input[y - 1][x - 1] == 'M' && input[y + 1][x + 1] == 'S') ||
                           (input[y - 1][x - 1] == 'S' && input[y + 1][x + 1] == 'M');

    var topRightDownLeft = (input[y + 1][x - 1] == 'M' && input[y - 1][x + 1] == 'S') ||
                            (input[y + 1][x - 1] == 'S' && input[y - 1][x + 1] == 'M');

    return topLeftDownRight && topRightDownLeft;
}