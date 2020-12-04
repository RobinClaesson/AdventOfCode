using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted('=');

            //Clean uo rules
            for (int i = 0; i < input.Count; i++)
            {
                input[i][1] = input[i][1].Replace(">", "").Replace(" ", "");
                input[i][0] = input[i][0].Replace(" ", "");

            }

            string image = ".#./..#/###";
            //string image = ".#.AAA/..#AAA/###AAA/.#.AAA/..#AAA/###AAA";

            //Part 1
            PrintImage(image);
            for (int iterations = 0; iterations < 5; iterations++)
            {
                //Creates grids
                string[,] grids = GetGrids(image);

                //Grids in every direction
                int gridDim = (int)Math.Sqrt(grids.Length);

                //Converts grid
                for (int y = 0; y < gridDim; y++)
                {
                    for (int x = 0; x < gridDim; x++)
                    {
                        //Match grid to rule
                        for (int i = 0; i < input.Count; i++)
                        {
                            string[] variations = Variations(grids[y, x]);

                            foreach (string variation in variations)
                                if (variation == input[i][0])
                                    grids[y, x] = input[i][1];
                        }
                    }
                }


                //Transfer grid to image
                image = "";
                for (int y = 0; y < gridDim; y++)
                {
                    int gridSize = grids[y, 0].Split('/').Length;

                    for (int row = 0; row < gridSize; row++)
                    {
                        for (int x = 0; x < gridDim; x++)
                        {
                            image += grids[y, x].Split('/')[row];
                        }

                        image += "/";
                    }
                }
                image = image.Substring(0, image.Length - 1);

                PrintImage(image);
                Console.ReadKey();
            }

            //Calculates pixels that ar on
            int on = 0;
            foreach (char c in image)
                if (c == '#')
                    on++;

            IO.Output(on);

            Console.ReadKey();
        }

        static string[,] GetGrids(string image)
        {
            string[] imageRows = image.Split('/');

            int imageSize = imageRows.Length;
            int gridSize = imageSize % 2 == 0 ? 2 : 3;
            int gridDim = imageSize / gridSize;

            string[,] grids = new string[gridDim, gridDim];

            for (int y = 0; y < gridDim; y++)
            {
                for (int x = 0; x < gridDim; x++)
                {
                    for (int row = y * gridSize; row < y * gridSize + gridSize; row++)
                    {
                        grids[y, x] += imageRows[row].Substring(x * gridSize, gridSize) + "/";
                    }

                    grids[y, x] = grids[y, x].Substring(0, grids[y, x].Length - 1);
                }
            }


            return grids;
        }

        static string[] Variations(string image)
        {
            List<string> variations = new List<string>();

            //Rotatations
            List<string> rotations = new List<string>();
            rotations.Add(image);
            rotations.Add(Rotate(rotations.Last()));
            rotations.Add(Rotate(rotations.Last()));
            rotations.Add(Rotate(rotations.Last()));

            //Flips
            foreach (string r in rotations)
            {
                variations.Add(r);
                variations.Add(FlipH(r));
                variations.Add(FlipV(r));
                variations.Add(FlipBoth(r));
            }


            return variations.ToArray();
        }

        static string Rotate(string original)
        {
            string result = "";
            string[] rows = original.Split('/');

            for (int x = 0; x < rows[0].Length; x++)
            {
                for (int y = rows.Length - 1; y >= 0; y--)
                {
                    result += rows[y][x];
                }

                result += "/";
            }

            result = result.Substring(0, result.Length - 1);
            return result;
        }

        static string FlipH(string original)
        {
            string[] rows = original.Split('/');
            string result = "";
            for (int y = 0; y < rows.Length; y++)
            {
                for (int x = rows[0].Length - 1; x >= 0; x--)
                {
                    result += rows[y][x];
                }

                result += "/";
            }

            return result.Substring(0, result.Length - 1);
        }

        static string FlipV(string original)
        {
            string[] rows = original.Split('/');
            string result = "";
            for (int y = rows.Length - 1; y >= 0; y--)
            {
                for (int x = 0; x < rows.Length; x++)
                {
                    result += rows[y][x];
                }

                result += "/";
            }

            return result.Substring(0, result.Length - 1);
        }

        static string FlipBoth(string original)
        {
            return FlipH(FlipV(original));
        }


        static void PrintImage(string image)
        {
            string[] rows = image.Split('/');

            foreach (string row in rows)
                Console.WriteLine(row);

            Console.WriteLine();
        }

    }
}
