using AoC.IO;
using AoC.Tools;
using System.Numerics;

var input = Input.Rows;

int[,] octopuses = new int[10, 10];

for (int y = 0; y < 10; y++)
    for (int x = 0; x < 10; x++)
        octopuses[y, x] = int.Parse("" + input[y][x]);


int flashes = 0, allFlashedIndex = 0, step = 1;

//Run untill all flashes at the same time, only count flashes for the first 100
while (allFlashedIndex == 0)
{
    //Increase by 1
    for (int y = 0; y < 10; y++)
        for (int x = 0; x < 10; x++)
            octopuses[y, x]++;

    List<Vector2> flashedPos = new List<Vector2>();
    bool hadFlash;

    //Check all squares untill we have not seen a flash
    do
    {
        hadFlash = false;

        for (int y = 0; y < 10; y++)
            for (int x = 0; x < 10; x++)
            {
                Vector2 point = new Vector2(x, y);
                if (octopuses[y, x] > 9 && !flashedPos.Contains(point))
                {
                    hadFlash = true;
                    flashedPos.Add(point);

                    if (step <= 100)
                        flashes++;


                    Vector2[] adjecentPoints = SquareGrid.AdjacentPoints(point);

                    //increase adjecent
                    foreach (var adjecent in adjecentPoints)
                    {
                        if (adjecent.X >= 0 && adjecent.X < 10 && adjecent.Y >= 0 && adjecent.Y < 10)
                            octopuses[(int)adjecent.Y, (int)adjecent.X]++;
                    }
                }
            }

        if (flashedPos.Count == 100)
            allFlashedIndex = step;


    } while (hadFlash);

    //Reset to 0
    for (int y = 0; y < 10; y++)
        for (int x = 0; x < 10; x++)
            if (octopuses[y, x] > 9)
                octopuses[y, x] = 0;


    step++;
}


Output.Answer(flashes);
Output.Answer(allFlashedIndex);