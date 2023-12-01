using AoC.IO;
using System.Linq;

Input.TestMode = false;
var input = Input.Rows;


// Part 1
int sum = 0;
foreach (var row in input)
{
    var nums = row.Where(c => c >= '0' && c <= '9').Select(c => int.Parse(c.ToString())).ToArray();
    sum += 10 * nums.First() + nums.Last();
}

Output.Answer(sum);

// Part 2
var words = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
sum = 0;
foreach (var row in input)
{
    var substrings = new List<string>();

    for (int i = 0; i < row.Length; i++)
        for (int j = i; j < row.Length; j++)
            substrings.Add(row.Substring(i, j - i + 1));

    var nums = substrings.Select(s => NumFromWord(s)).Where(i => i != -1).ToArray();
    sum += 10 * nums.First() + nums.Last();
}

Output.Answer(sum);

int NumFromWord(string word)
{
    if (word.Length == 1 && int.TryParse(word, out var res))
        return res;

    switch (word)
    {
        case "one": return 1;
        case "two": return 2;
        case "three": return 3;
        case "four": return 4;
        case "five": return 5;
        case "six": return 6;
        case "seven": return 7;
        case "eight": return 8;
        case "nine": return 9;
        default: return -1;
    }
}