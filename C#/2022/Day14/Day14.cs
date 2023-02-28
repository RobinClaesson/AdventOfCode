using AoC.IO;
using AoC.Tools;
using System.Numerics;

Input.TestMode = true;
var input = Input.Rows;

var points = new List<Vector2>();

foreach(var row in input)
{
    var corners = row.Split(" -> ").Select(s => Parser.ParseVector2(s)).ToList();
    
    for(int i = 1; i < corners.Count; i++)
    {
        var diff = Vector2.Normalize(corners[i] - corners[i - 1]);
    }
}

var dropPoint = new Vector2(500, 0);
var bottomRock = points.Max(p => p.Y);

var units = 0;
var overflow = false;

var downMovement = new Vector2(0, 1);
var leftMovement = new Vector2(-1, 1);
var rightMovement = new Vector2(1, 1);

while(!overflow)
{
    var sand = dropPoint;
    var falling = true;

    while(falling)
    {
        if(!points.Contains(sand + downMovement))
        {
            sand += downMovement;
        }

        else if (!points.Contains(sand + leftMovement))
        {
            sand += leftMovement;
        }

        else if (!points.Contains(sand + rightMovement))
        {
            sand += rightMovement;
        }

        else
        {
            points.Add(sand);
            falling = false;
        }
    }  
}