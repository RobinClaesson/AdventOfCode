using AoC.IO;
using Day_22;

Input.TestMode = false;
var input = Input.Rows;

var nodes = input.Skip(2)
    .Select(r => new Node(r))
    .ToList();

var validPairCount = nodes
    .Where(node => node.Used > 0)
    .Sum(node =>
        nodes.Where(other => other != node)
            .Count(other => node.Used <= other.Available)
    );

Output.Answer(validPairCount);

return;