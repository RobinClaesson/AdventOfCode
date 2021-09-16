using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
using System.Drawing;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> input = IO.InputRowsSplitted_Int(',');
            //Finding the outer borders of the grid (It's infinite but we dont care about infinite areas)
            int xMax = -1, yMax = -1;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i][0] > xMax)
                    xMax = input[i][0];

                if (input[i][1] > yMax)
                    yMax = input[i][1];
            }

            //Creates grid
            int[,] grid = new int[yMax + 1, xMax + 1];
            for (int y = 0; y <= yMax; y++)
            {
                for (int x = 0; x <= xMax; x++)
                {
                    int index = 0;
                    int shortest = MDist(x, y, input[0][0], input[0][1]);

                    for (int i = 1; i < input.Count; i++)
                    {
                        int md = MDist(x, y, input[i][0], input[i][1]);

                        if (md < shortest)
                        {
                            shortest = md;
                            index = i;
                        }

                        else if (md == shortest)
                            index = -1;
                    }

                    grid[y, x] = index;
                }
            }

            //If it is on the border it is infinate
            List<int> toCheck = new List<int>();
            for (int i = 0; i < input.Count; i++)
                toCheck.Add(i);

            //Left and right border
            for (int y = 0; y <= yMax; y++)
            {
                int i = grid[y, 0];

                if (toCheck.IndexOf(i) != -1)
                    toCheck.Remove(i);

                i = grid[y, xMax];

                if (toCheck.IndexOf(i) != -1)
                    toCheck.Remove(i);
            }

            //Top and bottom border
            for (int x = 0; x <= xMax; x++)
            {
                int i = grid[0, x];

                if (toCheck.IndexOf(i) != -1)
                    toCheck.Remove(i);

                i = grid[yMax, x];

                if (toCheck.IndexOf(i) != -1)
                    toCheck.Remove(i);
            }

            //Finds out the sizes of the non-infinite grid
            List<int> sizes = new List<int>();
            for (int i = 0; i < toCheck.Count; i++)
                sizes.Add(0);

            for (int y = 0; y <= yMax; y++)
                for (int x = 0; x <= xMax; x++)
                    for (int i = 0; i < toCheck.Count; i++)
                        if (toCheck[i] == grid[y, x])
                            sizes[i]++;

            //The largest non-infinite area 
            IO.Output(sizes.Max());

            //Part 2
            //Found out by testing values on x that theese limits, even though they seem small are way enough to cover. 
            //Its not optimized, but it runs fast so its ok i guess.
            int size = 0;
            for (int y = 0; y <= yMax; y++)
            {
                for (int x = 0; x <= xMax; x++)
                {
                    if (MDistSum(x, y, input) < 10000)
                        size++;
                }
            }

            IO.Output(size);
            Console.ReadKey();
        }


        private static int MDist(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private static int MDistSum(int x, int y, List<int[]> points)
        {
            int dist = 0;

            foreach (int[] point in points)
                dist += MDist(x, y, point[0], point[1]);

            return dist;
        }
    }

}
