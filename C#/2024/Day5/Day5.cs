using AoC.IO;

Input.TestMode = false;

var input = Input.Rows;

var pageRules = input.TakeWhile(x => x != "")
                     .Select(x => x.Split("|").Select(int.Parse).ToArray())
                     .ToList();
 
var updates = input.Skip(pageRules.Count + 1)
                   .Select(x => x.Split(",").Select(int.Parse).ToList())
                   .ToList();

var pages = pageRules.SelectMany(x => x).Distinct();
var prereqs = pages.ToDictionary(x => x, x => new List<int>());
pageRules.ForEach(x => prereqs[x[1]].Add(x[0]));

var validUpdates = updates.Where(IsValidUpdate);
var part1 = validUpdates.Select(x => x[x.Count / 2]).Sum();
Output.Answer(part1);

var invalids = updates.Except(validUpdates);
var comparer = new PageComprarer(prereqs);
var fixedInvalids = invalids.Select(x => x.OrderBy(x => x, comparer).ToList());

var part2 = fixedInvalids.Select(x => x[x.Count / 2]).Sum();
Output.Answer(part2);

bool IsValidUpdate(List<int> updates)
{
    for(int i = 0; i < updates.Count; i++)
    {
        var page = updates[i];
        var prereq = prereqs[page];
        var following = updates.Skip(i + 1);
        if (following.Any(x => prereq.Contains(x)))
            return false;
    }

    return true;
}

class PageComprarer : IComparer<int>
{
    Dictionary<int, List<int>> prereqs;

    public PageComprarer(Dictionary<int, List<int>> prereqs)
    {
        this.prereqs = prereqs;
    }

    int IComparer<int>.Compare(int x, int y)
    {
        return prereqs[x].Contains(y) ? 1 : -1;
    }
}
