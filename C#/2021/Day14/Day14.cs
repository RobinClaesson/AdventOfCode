using AoC.IO;

var input = Input.Rows;

Dictionary<string, string> rules = new Dictionary<string, string>();

var polymer = input[0];

input.RemoveAt(0);
input.RemoveAt(0);

foreach (var row in input)
{
    var rule = row.Replace(" -> ", ".").Split('.');
    rules.Add(rule[0], rule[1]);
}

for (int step = 0; step < 10; step++)
{
    var newPolymer = string.Empty;
    for (int i = 0; i < polymer.Length - 1; i++)
    {
        newPolymer += polymer[i];

        var pair = polymer.Substring(i, 2);
        if (rules.ContainsKey(pair))
            newPolymer += rules[pair];
    }

    newPolymer += polymer.Last();

    polymer = newPolymer;
}

var counts = polymer.GroupBy(c => c).OrderByDescending(g => g.Count());
Output.Answer(counts.First().Count() - counts.Last().Count());

for (int step = 0; step < 30; step++)
{
    var newPolymer = string.Empty;

    for (int i = 0; i < polymer.Length - 1; i++)
    {
        newPolymer += polymer[i];

        var pair = polymer.Substring(i, 2);
        if (rules.ContainsKey(pair))
            newPolymer += rules[pair];
    }

    newPolymer += polymer.Last();
    polymer = newPolymer;
}
counts = polymer.GroupBy(c => c).OrderByDescending(g => g.Count());
Output.Answer(counts.First().Count() - counts.Last().Count());