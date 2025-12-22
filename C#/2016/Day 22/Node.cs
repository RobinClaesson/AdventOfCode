using System.Reflection.PortableExecutable;

namespace Day_22;

public class Node
{
    public Node()
    {
    }

    public Node(string input)
    {
        var split = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var coords = split[0]
            .Replace("x", string.Empty)
            .Replace("y", string.Empty)
            .Split('-')[^2..]
            .Select(int.Parse)
            .ToArray();

        X = coords[0];
        Y = coords[1];

        var size = int.Parse(split[1][..^1]);
        Used = int.Parse(split[2][..^1]);
        Available = int.Parse(split[3][..^1]);
        
        if(Used + Available != size)
            throw new ArgumentException($"{Used} + {Available} != {size}");
    }

    public int X { get; set; }
    public int Y { get; set; }

    public int Used { get; set; }
    public int Available { get; set; }
    
}