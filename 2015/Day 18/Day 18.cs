using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
using System.Drawing;

namespace Day_18
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;
            Point size = new Point(input[0].Length, input.Count);
            int[,] map = new int[size.Y, size.X];

            for (int y = 0; y < input.Count; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == '.')
                        map[y, x] = 0;
                    else
                        map[y, x] = 1;
                }
            }
            Part1(size, map);
            Part2(size, map);
            Console.ReadKey();
        }

        private static void Part2(Point size, int[,] map)
        {
            int updates = 100;

            //Turns on the four corners
            map[0, 0] = 1;
            map[size.Y - 1, 0] = 1;
            map[0, size.X - 1] = 1;
            map[size.Y - 1, size.X - 1] = 1;

            for (int i = 0; i < updates; i++)
            {

                int[,] nextMap = new int[size.Y, size.X];

                for (int y = 0; y < size.Y; y++)
                {
                    for (int x = 0; x < size.X; x++)
                    {
                        int nSum = NeighbourSum(map, size, new Point(x, y));

                        if (nSum == 3 || (nSum == 2 && map[y, x] == 1) || (x == 0 && y == 0) || (x == 0 && y == size.Y - 1) || (x == size.X - 1 && y == size.Y - 1) || (x == size.X - 1 && y == 0))
                            nextMap[y, x] = 1;
                        else
                            nextMap[y, x] = 0;
                    }
                }

                map = nextMap;
            }

            int sum = 0;
            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    sum += map[y, x];
                }
            }

           IO.Output(sum);
        }

        private static void Part1(Point size, int[,] map)
        {
            int updates = 100;

            for (int i = 0; i < updates; i++)
            {


                int[,] nextMap = new int[size.Y, size.X];

                for (int y = 0; y < size.Y; y++)
                {
                    for (int x = 0; x < size.X; x++)
                    {
                        int nSum = NeighbourSum(map, size, new Point(x, y));

                        if (nSum == 3 || (nSum == 2 && map[y, x] == 1))
                            nextMap[y, x] = 1;
                        else
                            nextMap[y, x] = 0;
                    }
                }

                map = nextMap;
            }

            int sum = 0;
            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    sum += map[y, x];
                }
            }

            IO.Output(sum);
        }

        static void PrintMap(int[,] map, Point size)
        {
            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    if (map[y, x] == 1)
                        Console.Write("#");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        static void PrintNeughbourSum(int[,] map, Point size)
        {
            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    Console.Write(NeighbourSum(map, size, new Point(x, y)));


                }
                Console.WriteLine();
            }
        }

        static int NeighbourSum(int[,] map, Point size, Point pos)
        {
            int sum = 0;

            List<Point> neighbours = new List<Point> { new Point(pos.X+1, pos.Y),   // 1,0
                                                       new Point(pos.X+1, pos.Y-1), //1,-1
                                                       new Point(pos.X, pos.Y-1),   //0,-1
                                                       new Point(pos.X-1, pos.Y-1), //-1,-1
                                                       new Point(pos.X-1, pos.Y),   //-1,0
                                                       new Point(pos.X-1, pos.Y+1), //-1,1
                                                       new Point(pos.X, pos.Y+1),   //0,1
                                                       new Point(pos.X+1, pos.Y+1)  //1,1
            };

            foreach (Point neighbour in neighbours)
            {
                if (neighbour.X >= 0 && neighbour.X < size.X && neighbour.Y >= 0 && neighbour.Y < size.Y)
                {
                    sum += map[neighbour.Y, neighbour.X];
                }

            }

            return sum;
        }
    }
}
