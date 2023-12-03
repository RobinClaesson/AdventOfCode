using AoC.IO;
using AoC.Tools;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Numerics;
using System.Windows.Markup;

Input.TestMode = false;

var input = Input.Rows;

var gearNumbers = new List<(int num, int gearX, int gearY)>();
int sum1 = 0;
for (int y = 0; y < input.Count; y++)
{
    for (int x = 0; x < input[y].Length; x++)
    {
        if (char.IsDigit(input[y][x]))
        {
            var numberStart = x;
            while (x + 1 < input[y].Length && char.IsDigit(input[y][x + 1]))
                x++;

            var part = SearchForPart(y, numberStart, x);
            var number = int.Parse(input[y].Substring(numberStart, x - numberStart + 1));
            if (part.c != '.')
            {
                sum1 += number;
            }
            if(part.c == '*') 
            {
                gearNumbers.Add((number, part.x, part.y));
            }
        }
    }
}

Output.Answer(sum1);

var pairs = gearNumbers.GroupBy(g => (x: g.gearX,  y: g.gearY));
var sum2 = 0;

foreach(var pair in pairs)
{
    if(pair.Count() == 2)
    {

    var nums = pair.Select(g => g.num);
    var ratio = nums.Aggregate(1, (prod, next) => prod * next);
    sum2 += ratio;
    }
}

Output.Answer(sum2);

(char c, int x, int y) SearchForPart(int currentRow, int numberStart, int numberEnd)
{
    for (int y = currentRow - 1; y < input.Count && y <= currentRow + 1; y++)
    {
        if (y >= 0)
        {
            for (int x = numberStart - 1; x < input[y].Length && x <= numberEnd + 1; x++)
            {
                if (x >= 0)
                {
                    if (!char.IsAsciiDigit(input[y][x]) && input[y][x] != '.')
                    {
                        return (input[y][x], x, y);
                    }
                }
            }
        }
    }

    return ('.', -1, -1);
}
