using AoC.IO;

const long maxIp = 4294967295L;

Input.TestMode = false;
var input = Input.RowsSplittedAsLong('-');

var ranges = input
    .Select(r => new Range(r[0], r[1]))
    .ToList();

var merged = ranges.MergeRanges();
Output.Answer(merged[0].End + 1);

var bannedIps = merged.Sum(r => r.Length);
Output.Answer(maxIp - bannedIps + 1);

return;

internal class Range(long start, long end)
{
    public long Length => End - Start + 1;
    public long Start { get; set; } = start;
    public long End { get; set; } = end;
}

internal static class RangeMerger
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

            //If the next banned ip range starts lower than 2 away from current end they can be merged
            while (currentNode?.Next is not null && current.End >= currentNode.Next.Value.Start - 1)
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