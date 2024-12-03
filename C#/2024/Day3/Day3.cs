using AoC.IO;
using System.Text.RegularExpressions;

Input.TestMode = false;
var input = Input.All;

//part 1
var mulRegex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
var matches = mulRegex.Matches(input);
var part1 = matches.Select(m => m.Value)
                    .Select(m => m.Replace("mul(", "")
                                 .Replace(")", "")
                                 .Split(","))
                    .Select(m => int.Parse(m[0]) * int.Parse(m[1]))
                    .Sum();
Output.Answer(part1);

//part 2
var doRegex = new Regex(@"mul\(\d{1,3},\d{1,3}\)|(do\(\))|(don't\(\))");
matches = doRegex.Matches(input);

var part2 = 0;
var enabled = true;
foreach (Match match in matches)
{
    if (enabled && match.Captures[0].Value.StartsWith("mul"))
    {
        var numbers = match.Value.Replace("mul(", "")
                            .Replace(")", "")
                            .Split(",")
                            .Select(int.Parse)
                            .ToList();
        part2 += numbers[0] * numbers[1];

    }
    else if (match.Captures[0].Value.StartsWith("don't")) enabled = false;
    else if (match.Captures[0].Value.StartsWith("do")) enabled = true;
}
Output.Answer(part2);