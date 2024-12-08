using AoC.IO;
using System.Numerics;

Input.TestMode = false;

var input = Input.Rows;

var antennaTypes = input.SelectMany(row => row)
                        .Where(c => c != '.')
                        .Distinct()
                        .ToList();

var antennaLocations = antennaTypes.ToDictionary(a => a, a => new List<Vector2>());
var antennas = input.Select(row => row.Select((c, i) => (Antenna: c, Index: i))
                                     .Where(x => x.Antenna != '.')
                                     .ToList()).ToList();

for (int y = 0; y < antennas.Count; y++)
    foreach (var (antenna, x) in antennas[y])
        antennaLocations[antenna].Add(new Vector2(x, y));

var antinodesPart1 = new HashSet<Vector2>();
var antinodesPart2 = new HashSet<Vector2>();

foreach (var (antenna, locations) in antennaLocations)
{
    for (int i = 0; i < locations.Count; i++)
    {
        var location = locations[i];
        for (int j = i + 1; j < locations.Count; j++)
        {
            var otherLocation = locations[j];
            var diff = otherLocation - location;

            antinodesPart1.Add(location - diff);
            antinodesPart1.Add(otherLocation + diff);

            var divisor = (int)BigInteger.GreatestCommonDivisor((int)diff.X, (int)diff.Y);
            diff /= divisor;

            var pos = location;
            while (IsInBounds(pos))
            {
                antinodesPart2.Add(pos);
                pos -= diff;
            }

            pos = otherLocation;
            while (IsInBounds(pos))
            {
                antinodesPart2.Add(pos);
                pos += diff;
            }
        }
    }
}

antinodesPart1 = antinodesPart1.Where(IsInBounds)
                     .ToHashSet();

Output.Answer(antinodesPart1.Count);
Output.Answer(antinodesPart2.Count);

bool IsInBounds(Vector2 pos) => pos.X >= 0 && pos.Y >= 0 && pos.X < input[0].Length && pos.Y < input.Count;