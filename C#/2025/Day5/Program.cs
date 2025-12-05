using AoC.IO;

Input.TestMode = false;
var input = Input.Rows;

var freshRanges = input
    .TakeWhile(row => !string.IsNullOrWhiteSpace(row))
    .Select(row => row.Split('-').Select(long.Parse).ToArray())
    .Select(range => new Range(range[0], range[1]))
    .MergeRanges();

var ingredients = input
    .SkipWhile(row => !string.IsNullOrWhiteSpace(row))
    .Skip(1)
    .Select(long.Parse)
    .ToList();

Output.Answer(ingredients.Count(i => freshRanges.Any(r => r.IsInRange(i))));
Output.Answer(freshRanges.Sum(r => r.Length));
class Range(long start, long end)
{
    public bool IsInRange(long ingredient) => ingredient >= Start && ingredient <= End;
    public long Length => End - Start + 1;
    public long Start { get; set; } = start;
    public long End { get; set; } = end;
}

static class RangeMerger
{
    public static List<Range> MergeRanges(this IEnumerable<Range> ranges)
    {
        var mergedRanges = new LinkedList<Range>(ranges
            .OrderBy(r => r.Start)
            .ThenBy(r => r.End));
        var currentNode = mergedRanges.First;
        while (currentNode is not null)
        {
            var current = currentNode.Value;
            while (currentNode?.Next is not null && current.End >= currentNode.Next.Value.Start)
            {
                if (current.End < currentNode.Next.Value.End)
                    current.End = currentNode.Next.Value.End;

                mergedRanges.Remove(currentNode.Next);
            }

            currentNode = currentNode!.Next;
        }

        return mergedRanges.ToList();
    }
}