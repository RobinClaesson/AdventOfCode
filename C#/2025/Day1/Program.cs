using AoC.IO;

Input.TestMode = false;
var input = Input.Rows
    .Select(row => new Move(row[0] == 'R', int.Parse(row[1..])))
    .ToList();

Output.Answer(GetPassword(input));

var expandedInput = new List<Move>();
input.ForEach(move => expandedInput.AddRange(Enumerable.Repeat(move with { Steps = 1 }, move.Steps)));
Output.Answer(GetPassword(expandedInput));

int PositiveMod(int x, int mod) => (x % mod + mod) % mod;

int GetPassword(List<Move> moves)
{
    var password = 0;
    var dial = 50;

    foreach (var move in moves)
    {
        dial += move.Right ? move.Steps : -move.Steps;

        dial = PositiveMod(dial, 100);
        if (dial == 0)
            password++;
    }

    return password;
}

internal record Move(bool Right, int Steps);