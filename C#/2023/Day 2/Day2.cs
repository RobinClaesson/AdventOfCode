using AoC.IO;

Input.TestMode = false;
var input = Input.RowsSplitted(':').Select(x => (Id: int.Parse(x[0].Replace("Game ", "")), Sets: x[1].Split(';'))).ToList();

Output.Answer(input.Where(g => g.Sets.All(IsValidSet)).Sum(g => g.Id));
Output.Answer(input.Select(x => x.Sets.Select(GetDrawsInSet)).Sum(GetPowerLevel));

bool IsValidSet(string setString)
{
    var draws = GetDrawsInSet(setString);

    var reds = draws.Where(x => x.Color == "red").Sum(x => x.Count);
    var greens = draws.Where(x => x.Color == "green").Sum(x => x.Count);
    var blues = draws.Where(x => x.Color == "blue").Sum(x => x.Count);

    if (reds > 12 || greens > 13 || blues > 14)
        return false;

    return true;
}

int GetPowerLevel(IEnumerable<List<(int Count, string Color)>> sets)
{
    var reds = sets.SelectMany(x => x.Where(d => d.Color == "red")).Max(d => d.Count);
    var greens = sets.SelectMany(x => x.Where(d => d.Color == "green")).Max(d => d.Count);
    var blues = sets.SelectMany(x => x.Where(d => d.Color == "blue")).Max(d => d.Count);

    return reds * greens * blues;
}

List<(int Count, string Color)> GetDrawsInSet(string setString) => setString.Split(',')
                                                                        .Select(x => x.Split(' ')
                                                                        .Where(s => s != string.Empty).ToArray())
                                                                        .Select(x => (int.Parse(x[0]), x[1])).ToList();