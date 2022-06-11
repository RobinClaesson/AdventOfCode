using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day11
{
    class Day11
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

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

                List<Point2> flashedPos = new List<Point2>();
                bool hadFlash;

                //Check all squares untill we have not seen a flash
                do
                {
                    hadFlash = false;

                    for (int y = 0; y < 10; y++)
                        for (int x = 0; x < 10; x++)
                        {
                            Point2 point = new Point2(x, y);
                            if (octopuses[y, x] > 9 && !flashedPos.Contains(point))
                            {
                                hadFlash = true;
                                flashedPos.Add(point);

                                if (step <= 100)
                                    flashes++;


                                Point2[] adjecentPoints = point.AdjacentPoints();

                                //increase adjecent
                                foreach (Point2 adjecent in adjecentPoints)
                                {
                                    if (adjecent.X >= 0 && adjecent.X < 10 && adjecent.Y >= 0 && adjecent.Y < 10)
                                        octopuses[adjecent.Y, adjecent.X]++;
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


            IO.Output(flashes);
            IO.Output(allFlashedIndex);

            Console.ReadKey();
        }
    }
}
