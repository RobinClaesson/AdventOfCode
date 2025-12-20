using AoC.IO;

Input.TestMode = false;
var input = Input.RowsSplitted(' ');

var initial = Input.TestMode ? "abcde" : "abcdefgh";
var part1 = input.Aggregate(initial, Scramble);
Output.Answer(part1);

input.Reverse();
initial = Input.TestMode ? part1 : "fbgdceah";
Output.Answer(input.Aggregate(initial, Unscramble));

return;

string Scramble(string password, string[] instruction) => instruction[0] switch
{
    "swap" => Swap(password, instruction),
    "reverse" => Reverse(password, instruction),
    "rotate" => Rotate(password, instruction),
    "move" => Move(password, instruction),
    _ => password
};

string Swap(string password, string[] instruction) => instruction[1] == "position"
    ? SwapPositions(password, instruction)
    : SwapCharacters(password, instruction);

string SwapPositions(string password, string[] instruction)
{
    try
    {
        var x = int.Parse(instruction[2]);
        var y = int.Parse(instruction[5]);
        return SwapExecute(password, x, y);
    }
    catch
    {
        return password;
    }
}

string SwapCharacters(string password, string[] instruction)
{
    var x = password.IndexOf(instruction[2][0]);
    var y = password.IndexOf(instruction[5][0]);
    return SwapExecute(password, x, y);
}

string SwapExecute(string password, int x, int y)
{
    var characters = password.ToCharArray();
    (characters[x], characters[y]) = (characters[y], characters[x]);

    return new string(characters);
}

string Reverse(string password, string[] instruction)
{
    var x = int.Parse(instruction[2]);
    var y = int.Parse(instruction[4]);

    var start = password.Take(x);
    var middle = password.Skip(x).Take(y - x + 1).Reverse();
    var end = password.Skip(y + 1);

    return new string(start.Concat(middle).Concat(end).ToArray());
}

string Rotate(string password, string[] instruction)
{
    return instruction[1] switch
    {
        "left" => RotateLeft(password, int.Parse(instruction[2])),
        "right" => RotateRight(password, int.Parse(instruction[2])),
        _ => RotateAround(password, instruction.Last()[0])
    };
}

string RotateLeft(string password, int steps)
{
    var start = password[steps..];
    var end = password[..steps];
    return $"{start}{end}";
}

string RotateRight(string password, int steps)
{
    var start = password[^steps..];
    var end = password[..^steps];
    return $"{start}{end}";
}

string RotateAround(string password, char c)
{
    var index = password.IndexOf(c);
    var rotated = RotateRight(password, 1);
    rotated = RotateRight(rotated, index);
    return index >= 4 ? RotateRight(rotated, 1) : rotated;
}

string Move(string password, string[] instruction)
{
    var x = int.Parse(instruction[2]);
    var y = int.Parse(instruction[5]);

    var characters = password.ToCharArray().ToList();
    var toMove = characters[x];
    characters.RemoveAt(x);
    characters.Insert(y, toMove);

    return new string(characters.ToArray());
}

string Unscramble(string password, string[] instruction) => instruction[0] switch
{
    "swap" => Swap(password, instruction),
    "reverse" => Reverse(password, instruction),
    "rotate" => UnscrambleRotate(password, instruction),
    "move" => UnscrambleMove(password, instruction),
    _ => password
};

string UnscrambleRotate(string password, string[] instruction)
{
    return instruction[1] switch
    {
        "left" => RotateRight(password, int.Parse(instruction[2])),
        "right" => RotateLeft(password, int.Parse(instruction[2])),
        _ => UnscrambleRotateAround(password, instruction.Last()[0])
    };
}

string UnscrambleMove(string password, string[] instruction)
{
    (instruction[2], instruction[5]) = (instruction[5], instruction[2]);
    return Move(password, instruction);
}

string UnscrambleRotateAround(string password, char c)
{
    //If it looks stupid but works I guess
    for (var i = 0; i < password.Length; i++)
    {
        var candidate = RotateLeft(password, i);
        var result = RotateAround(candidate, c);

        if (result == password)
            return candidate;
    }

    return password;
}