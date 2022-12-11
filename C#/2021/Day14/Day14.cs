using AoC.IO;

/*
 * Since the string for p2 is WAY (like TB worth of data) to big to work on we can't build the entire sequence.
 * This solutions is based upon the insight that all the combinations of 2 letters have a rule.
 * Therefore, there will be inserted a new char between each par of chars, so we don't have to keep track of how
 * neighnbouring combinations are affected by a change. Instead of building the string, we keep count of how many
 * of each par exists in the polymer. For each pair we increase the ammount on the 2 new created pairs and clear
 * its own value. This way we know exactly whats in the string without having to build it. 
*/

Input.TestMode = false;
var fullInput = Input.All;

//Couldnt be bothered with regex for this
var elements = fullInput.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", string.Empty).
    Replace("-", string.Empty).Replace(">", string.Empty).Distinct();

var rules = new Dictionary<string, (string pair1, string pair2)>();
var pairCountBase = new Dictionary<string, ulong>();

//All possible pairs
foreach (char e1 in elements)
    foreach (char e2 in elements)
        pairCountBase.Add($"{e1}{e2}", 0);

var pairCount = new Dictionary<string, ulong>(pairCountBase);

//Pairs in start polymer
var inputRows = Input.Rows;
for (int i = 0; i < inputRows[0].Length - 1; i++)
{
    var pair = inputRows[0].Substring(i, 2);
    pairCount[pair]++;
}

//Rules
inputRows.RemoveRange(0, 2);
foreach (var row in inputRows)
{
    var s = row.Split(" -> ");

    var pair1 = $"{s[0][0]}{s[1]}";
    var pair2 = $"{s[1]}{s[0][1]}";

    rules.Add(s[0], (pair1, pair2));
}

//Calculation
for (int i = 1; i <= 40; i++)
{
    var nextCount = new Dictionary<string, ulong>(pairCountBase);

    foreach (var pair in pairCount)
    {
        var newPairs = rules[pair.Key];
        nextCount[newPairs.pair1] += pair.Value;
        nextCount[newPairs.pair2] += pair.Value;
    }

    pairCount = nextCount;

    if (i == 10)
        CalculateResult(pairCount);
}
CalculateResult(pairCount);

Console.WriteLine();

void CalculateResult(Dictionary<string, ulong> pairCount)
{
    var letterCount = new Dictionary<char, ulong>();

    foreach (var e in elements)
        letterCount.Add(e, 0);

    foreach (var pair in pairCount)
    {
        letterCount[pair.Key[0]] += pair.Value;
        letterCount[pair.Key[1]] += pair.Value;
    }

    var most = letterCount.Max(l => l.Value) / 2 + 1;
    var least = letterCount.Min(l => l.Value) / 2;

    Output.Answer(most - least);
}