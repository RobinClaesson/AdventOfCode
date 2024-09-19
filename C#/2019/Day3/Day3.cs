using AoC.IO;
using System.Numerics;

var input = Input.RowsSplitted(',');


var wire1 = TraceWire(input[0]);
var wire2 = TraceWire(input[1]);

var part1 = wire1.Intersect(wire2)
                 .Where(p => p != Vector2.Zero)
                 .Select(p => Math.Abs(p.X) + Math.Abs(p.Y))
                 .Min();

Output.Answer(part1) ;

var part2 = wire1.Intersect(wire2)
                 .Where(p => p != Vector2.Zero)
                 .Select(p => wire1.IndexOf(p) + wire2.IndexOf(p))
                 .Min();

Output.Answer(part2);

List<Vector2> TraceWire(string[] wireInfo)
{
    var wirePoints = new List<Vector2> { Vector2.Zero };
    
    foreach(var instruction in wireInfo)
    {
        var direction = instruction[0];
        var distance = int.Parse(instruction[1..]);
        
        var lastPoint = wirePoints.Last();
        
        for (int i = 1; i <= distance; i++)
        {
            var newPoint = direction switch
            {
                'U' => lastPoint + new Vector2(0, -i),
                'D' => lastPoint + new Vector2(0, i),
                'L' => lastPoint + new Vector2(-i, 0),
                'R' => lastPoint + new Vector2(i, 0),
                _ => throw new Exception("Invalid direction")
            };
            
            wirePoints.Add(newPoint);
        }
    }

    return wirePoints;
}