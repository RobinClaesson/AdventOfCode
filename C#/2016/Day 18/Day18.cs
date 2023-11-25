using AoC.IO;
using System.Text;

Input.TestMode = false;

var input = Input.All;

var safe = 0;

var row = new string(input);
var createsTrap = new string[] { "^^.", ".^^", "^..", "..^" };
for (int i = 0; i < 40; i++)
{
    safe += row.Count(c => c == '.');
    var nextFrom = $".{row}.";

    var sb = new StringBuilder();

    for (int j = 1; j < input.Length + 1; j++)
        sb.Append(createsTrap.Contains(nextFrom.Substring(j - 1, 3)) ? "^" : ".");

    row = sb.ToString();
}

Output.Answer(safe);

for (int i = 0; i < 400000 - 40; i++)
{
    safe += row.Count(c => c == '.');
    var nextFrom = $".{row}.";

    var sb = new StringBuilder();

    for (int j = 1; j < input.Length + 1; j++)
        sb.Append(createsTrap.Contains(nextFrom.Substring(j - 1, 3)) ? "^" : ".");

    row = sb.ToString();
}

Output.Answer(safe);