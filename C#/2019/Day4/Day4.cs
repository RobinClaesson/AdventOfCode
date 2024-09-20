using AoC.IO;
using System.Text.RegularExpressions;

var input = Input.All.Split('-')
                    .Select(int.Parse)
                    .ToArray();

var increasingNumberRegex = new Regex(@"0*1*2*3*4*5*6*7*8*9*$");    // Matches any numbers that is in increasing order
var groupRegex = new Regex(@"(\d)\1{1,}");                          // Matches any digit that is repeated 2 or more times

var part1 = 0;
var part2 = 0;

var part1List = new List<string>();
var part2List = new List<string>();

for (int i = input[0]; i <= input[1]; i++)
{
    var password = i.ToString();

    var isIncreasing = increasingNumberRegex.Match(password).Length == password.Length;
    var groupMatch = groupRegex.Match(password);

    if (isIncreasing & groupMatch.Success)
    {
        part1++;
        part1List.Add(password);

        while (groupMatch.Success)
        {
            if (groupMatch.Length == 2)
            {
                part2List.Add(password);
                part2++;
                break;
            }
            groupMatch = groupMatch.NextMatch();
        }
    }
}

Output.Answer(part1);
Output.Answer(part2);
