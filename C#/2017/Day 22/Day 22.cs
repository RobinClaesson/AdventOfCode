using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_22
{
    class Program
    {
        enum Direction { Up, Right, Down, Left };
        static Direction dir = Direction.Up;
        static List<List<char>> map = IO.InputChars;
        static int x = 0, y = 0;
        static void Main(string[] args)
        {
            Part1();
            Part2();

            Console.ReadKey();

        }

        static void Part1()
        {
            x = map[0].Count / 2;
            y = map.Count / 2;
            int causedInfection = 0;
            for (int updates = 0; updates < 10000; updates++)
            {
                //Console.Clear();
                //PrintMap();
                //Console.WriteLine("Updates: " + updates + " | Casued Infections: " + causedInfection);
                //Console.ReadKey();

                //on clean
                if (map[y][x] == '.')
                {
                    TurnLeft();

                    causedInfection++;
                    map[y][x] = '#';

                    Move();
                }

                //On infected
                else
                {
                    TurnRight();

                    map[y][x] = '.';

                    Move();
                }


            }

            IO.Output(causedInfection);
        }

        static void Part2()
        {
            map = IO.InputChars;
            x = map[0].Count / 2;
            y = map.Count / 2;
            int causedInfection = 0;
            dir = Direction.Up;
            for (int updates = 0; updates < 10000000; updates++)
            {
                //Console.Clear();
                //PrintMap();
                //Console.WriteLine("Updates: " + updates);
                //Console.WriteLine("Casued Infections: " + causedInfection);
                //Console.WriteLine("Direction: " + dir.ToString());
                //Console.ReadKey();

                //on clean
                if (map[y][x] == '.')
                {
                    TurnLeft();

                    map[y][x] = 'W';

                    Move();
                }

                //On Weakened
                else if (map[y][x] == 'W')
                {
                    causedInfection++;
                    map[y][x] = '#';

                    Move();
                }

                //On infected
                else if (map[y][x] == '#')
                {
                    TurnRight();

                    map[y][x] = 'F';

                    Move();
                }

                //On flaged
                else if (map[y][x] == 'F')
                {
                    //Reverse
                    TurnRight();
                    TurnRight();

                    map[y][x] = '.';

                    Move();
                }


            }

            IO.Output(causedInfection, true);
        }


        static void TurnRight()
        {
            dir++;

            if (dir > Direction.Left)
                dir = Direction.Up;
        }

        static void TurnLeft()
        {
            dir--;
            if (dir < Direction.Up)
                dir = Direction.Left;
        }

        static void Move()
        {
            //Moves
            switch (dir)
            {
                case Direction.Up:
                    y--;
                    break;

                case Direction.Down:
                    y++;
                    break;

                case Direction.Right:
                    x++;
                    break;

                case Direction.Left:
                    x--;
                    break;
            }

            //Controls we still are in map
            while (y < 0) //Overstept upwards
            {
                List<char> row = new List<char>();
                for (int i = 0; i < map[0].Count; i++)
                    row.Add('.');

                map.Insert(0, row);
                y++;
            }

            while (y >= map.Count) //Overstepts Downwards
            {
                List<char> row = new List<char>();
                for (int i = 0; i < map[0].Count; i++)
                    row.Add('.');

                map.Add(row);
            }

            while (x < 0) //Oversteps Left
            {
                for (int i = 0; i < map.Count; i++)
                {
                    map[i].Insert(0, '.');
                }
                x++;
            }

            while (x >= map[y].Count) //Oversteps rigth
            {
                for (int i = 0; i < map.Count; i++)
                {
                    map[i].Add('.');
                }
            }

        }


        static void PrintMap()
        {
            for (int pY = 0; pY < map.Count; pY++)
            {
                for (int pX = 0; pX < map[pY].Count; pX++)
                {
                    if (pY == y && pX == x)
                        Console.Write("[");
                    else
                        Console.Write(" ");

                    Console.Write(map[pY][pX]);

                    if (pY == y && pX == x)
                        Console.Write("]");
                    else
                        Console.Write(" ");

                }
                Console.WriteLine();
            }
        }
    }
}

