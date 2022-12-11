using AoC.IO;
using System.Text;
using System.Text.RegularExpressions;

Input.TestMode = true;
var input = Input.Rows;

var polymer = input[0];
input.RemoveRange(0, 2);

Dictionary<string, string> rules = new Dictionary<string, string>();
foreach (var row in input)
{
    var s = row.Split(" -> ");
    rules.Add(s[0], s[1]);
}

var nextPolymer = new StringBuilder();
var matches = new List<int>();

for (var steps = 0; steps < 10; steps++)
{
    
    foreach(var key in rules.Keys)
    {
       
    }


    foreach (var match in matches)
    {
        polymer = polymer.Insert(match.Index + 1, rules[match.Value]);
    }
    matches.Clear();
    //for (var i = 0; i < polymer.Length - 1; i++)
    //{
    //    var sub = polymer.Substring(i, 2);
    //    if (rules.ContainsKey(sub))
    //        nextPolymer.Append(rules[sub]);
    //    else
    //        nextPolymer.Append(polymer[i]);
    //}
    //nextPolymer.Append(polymer.Last());
    //polymer = nextPolymer.ToString();
    //nextPolymer.Clear();
}

var groups = polymer.GroupBy(c => c);
var most = groups.Max(g => g.Count());
var least = groups.Min(g => g.Count());

Output.Answer(most - least);

//for (var steps = 0; steps < 30; steps++)
//{

//    for (var i = 0; i < polymer.Length - 1; i++)
//    {
//        var sub = polymer.Substring(i, 2);
//        if (rules.ContainsKey(sub))
//            nextPolymer.Append(rules[sub]);
//        else
//            nextPolymer.Append(polymer[i]);
//    }
//    nextPolymer.Append(polymer.Last());
//    polymer = nextPolymer.ToString();
//    nextPolymer.Clear();
//}

//groups = polymer.GroupBy(c => c);
//most = groups.Max(g => g.Count());
//least = groups.Min(g => g.Count());

//Output.Answer(most - least);