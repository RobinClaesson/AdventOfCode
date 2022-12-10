using AoC.IO;
using System.Numerics;

var input = Input.Rows;

var inputDots = new List<Vector2>();

var row = -1;
while (input[++row] != "")
{
    var numbers = input[row].Split(',');
    inputDots.Add(new Vector2
    {
        X = int.Parse(numbers[0]),
        Y = int.Parse(numbers[1])
    });
}

var dots = new bool[(int)inputDots.OrderByDescending(d => d.X).First().X + 1, (int)inputDots.OrderByDescending(d => d.Y).First().Y + 1];
foreach (Vector2 point in inputDots)
{
    dots[(int)point.X, (int)point.Y] = true;
}
bool first = true;

while (++row < input.Count)
{
    var foldInfo = input[row].Split(' ').Last().Split('=');

    if (foldInfo[0] == "y")
        dots = FoldY(dots, int.Parse(foldInfo[1]));
    else
        dots = FoldX(dots, int.Parse(foldInfo[1]));

    if (first)
    {
        Output.Answer((from bool dot in dots where dot select dot).Count());
        first = false;
    }
}

Output.Answer("");
PrintDots(dots);

bool[,] FoldY(bool[,] dots, int foldRow)
{
    bool[,] result = new bool[dots.GetLength(0), foldRow];

    for (int y = 0; y < dots.GetLength(1); y++)
    {
        for (int x = 0; x < dots.GetLength(0); x++)
        {
            if (dots[x, y])
                if (y < foldRow)
                {
                    result[x, y] = true;
                }
                else if (y > foldRow)
                {

                    result[x, foldRow - (y - foldRow)] = true;
                }
        }
    }

    return result;
}

bool[,] FoldX(bool[,] dots, int foldCol)
{
    bool[,] result = new bool[foldCol, dots.GetLength(1)];

    for (int y = 0; y < dots.GetLength(1); y++)
    {
        for (int x = 0; x < dots.GetLength(0); x++)
        {
            if (dots[x, y])
                if (x < foldCol)
                {
                    result[x, y] = true;
                }
                else if (x > foldCol)
                {
                    result[foldCol - (x - foldCol), y] = true;
                }
        }
    }

    return result;
}

void PrintDots(bool[,] dots)
{

    for (int y = 0; y < dots.GetLength(1); y++)
    {
        for (int x = 0; x < dots.GetLength(0); x++)
        {
            if (dots[x, y])
                Console.Write("#");
            else
                Console.Write(" ");
        }

        Console.WriteLine();
    }

}