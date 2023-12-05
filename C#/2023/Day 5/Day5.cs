using AoC.IO;
using System.ComponentModel.DataAnnotations;

Input.TestMode = false;

var sections = Input.All.Split("\r\n\r\n").Select(r => r.Split(":")[1].Trim()).ToList();

var seeds = sections[0].Split(' ').Select(s => long.Parse(s)).ToList();

var maps = Enumerable.Range(1, sections.Count - 1).Select(i => ParseMap(i)).ToList();


var lowestLocation = long.MaxValue;
foreach (var seed in seeds)
{
    var value = seed;
    foreach (var map in maps)
    {
        value = ApplyMap(value, map);
    }

    if (lowestLocation > value)
        lowestLocation = value;
}

Output.Answer(lowestLocation);

lowestLocation = 0;
for (int i = 0; i < seeds.Count; i += 2)
{
    for(int j = 0; j < seeds[i+1]; j++)
    {
        var value = seeds[i];
        foreach (var map in maps)
        {
            value = ApplyMap(value, map);
        }

        if(lowestLocation > value) 
            lowestLocation = value;
    }
}

Output.Answer(lowestLocation);

List<List<long>> ParseMap(int sectionIndex)
    => sections[sectionIndex].Split("\r\n")
                                .Select(s => s.Split(' ')
                                    .Select(s => long.Parse(s)).ToList())
                                .ToList();


long ApplyMap(long number, List<List<long>> map)
{
    foreach (var mapEntry in map)
    {
        var destinationStart = mapEntry[0];
        var sourceStart = mapEntry[1];
        var rangeLengths = mapEntry[2];

        if (number >= sourceStart && number <= sourceStart + rangeLengths)
        {
            return destinationStart + (number - sourceStart);
        }
    }

    return number;
}
