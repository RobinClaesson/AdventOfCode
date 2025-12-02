using System.Text.RegularExpressions;
using AoC.IO;

//Capture some digits at the start of a line,
//then the exact same digits repeat one additional times until the end of the line
var part1InvalidRegex = new Regex(@"^(\d+)\1$", RegexOptions.Multiline);

//Capture some digits at the start of a line,
//then the exact same digits repeat one or more additional times until the end
var part2InvalidRegex = new Regex(@"^(\d+)(?:\1)+$", RegexOptions.Multiline);

Input.TestMode = false;
var input = Input.Split(',')
    .Select(rangeString => rangeString.Split('-', StringSplitOptions.RemoveEmptyEntries))
    .Select(ids => new IdRange(long.Parse(ids[0]), long.Parse(ids[1]))).ToList();

Output.Answer(input.SelectMany(range => FindInvalidIds(range, part1InvalidRegex)).Sum());
Output.Answer(input.SelectMany(range => FindInvalidIds(range, part2InvalidRegex)).Sum());

List<long> FindInvalidIds(IdRange range, Regex invalidIdRegex)
{
    var invalidIds = new List<long>();
    for (var id = range.First; id <= range.Last; id++)
    {
        if (invalidIdRegex.IsMatch(id.ToString()))
            invalidIds.Add(id);
    }

    return invalidIds;
}

internal record IdRange(long First, long Last);