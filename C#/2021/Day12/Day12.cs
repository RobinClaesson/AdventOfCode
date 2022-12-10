using AoC.IO;

List<string> paths = new List<string>();
Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();

var input = Input.Rows;

foreach (var row in input)
{
    var caves = row.Replace(" ", "").Split('-');

    if (!connections.ContainsKey(caves[0]))
        connections.Add(caves[0], new List<string>());
    if (!connections.ContainsKey(caves[1]))
        connections.Add(caves[1], new List<string>());

    if (caves[1] != "start")
        connections[caves[0]].Add(caves[1]);
    if (caves[0] != "start")
        connections[caves[1]].Add(caves[0]);
}

Part1("start");
Output.Answer(paths.Count);

paths.Clear();
Part2("start");
Output.Answer(paths.Count);

void Part1(string path)
{
    var splitPath = path.Split(',');

    foreach (var connection in connections[splitPath.Last()])
    {
        if (connection == "end")
        {
            paths.Add($"{path},{connection}");
        }
        else if (connection[0] < 'a' || !splitPath.Contains(connection))
        {
            Part1($"{path},{connection}");
        }
    }
}

void Part2(string path)
{
    var splitPath = path.Split(',');

    foreach (var connection in connections[splitPath.Last()])
    {
        if (connection == "end")
        {
            paths.Add($"{path},{connection}");
        }
        else if (connection[0] < 'a' || !splitPath.Contains(connection))
        {
            Part2($"{path},{connection}");
        }
        else
        {
            var smallCavesVisitedTwice = splitPath.Where(x => x[0] >= 'a').GroupBy(x => x).Where(x => x.Count() > 1).Count();

            if (smallCavesVisitedTwice == 0)
            {
                Part2($"{path},{connection}");
            }
        }
    }
}