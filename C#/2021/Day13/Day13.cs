using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = IO.InputRows;

            var inputDots = new List<Point2>();

            var row = -1;
            while (input[++row] != "")
            {
                var numbers = input[row].Split(',');
                inputDots.Add(new Point2
                {
                    X = int.Parse(numbers[0]),
                    Y = int.Parse(numbers[1])
                });
            }


            var dots = new bool[inputDots.OrderByDescending(d => d.X).First().X + 1, inputDots.OrderByDescending(d => d.Y).First().Y + 1];
            foreach (Point2 point in inputDots)
            {
                dots[point.X, point.Y] = true;
            }
            bool first = true;

            while (++row < input.Count)
            {
                var foldInfo = input[row].Split(' ').Last().Split('=');

                if (foldInfo[0] == "y")
                    dots = FoldY(dots, int.Parse(foldInfo[1]));
                else
                    dots = FoldX(dots, int.Parse(foldInfo[1]));

                if (first)
                {
                    IO.Output((from bool dot in dots where dot select dot).Count());
                    first = false;
                }
            }

            IO.Output("");
            PrintDots(dots);
            Console.ReadKey();
        }

        private static bool[,] FoldY(bool[,] dots, int foldRow)
        {
            bool[,] result = new bool[dots.GetLength(0), foldRow];

            for (int y = 0; y < dots.GetLength(1); y++)
            {
                for (int x = 0; x < dots.GetLength(0); x++)
                {
                    if (dots[x, y])
                        if (y < foldRow)
                        {
                            result[x, y] = true;
                        }
                        else if (y > foldRow)
                        {

                            result[x, foldRow - (y - foldRow)] = true;
                        }
                }
            }

            return result;
        }

        private static bool[,] FoldX(bool[,] dots, int foldCol)
        {
            bool[,] result = new bool[foldCol, dots.GetLength(1)];

            for (int y = 0; y < dots.GetLength(1); y++)
            {
                for (int x = 0; x < dots.GetLength(0); x++)
                {
                    if (dots[x, y])
                        if (x < foldCol)
                        {
                            result[x, y] = true;
                        }
                        else if (x > foldCol)
                        {
                            result[foldCol - (x - foldCol), y] = true;
                        }
                }
            }

            return result;
        }

        private static void PrintDots(bool[,] dots)
        {

            for (int y = 0; y < dots.GetLength(1); y++)
            {
                for (int x = 0; x < dots.GetLength(0); x++)
                {
                    if (dots[x, y])
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }

        }

    }
}
