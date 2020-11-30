using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Data.SqlTypes;
using System.Media;

namespace Day_1
{
    class Program
    {
        static bool log = false;
        enum Direction { North, East, South, West }
        static void Main(string[] args)
        {
            List<string> input = IO.InputSplitted(',');

            IO.Output(StepsToLast(input));
            IO.Output(StepsToFirstRevist(input));

            Console.ReadKey();
        }

        private static float StepsToLast(List<string> input)
        {
            Direction direction = Direction.North;
            Vector2 pos = new Vector2(0, 0);

            foreach (string instruction in input)
            {

                if (instruction != "")
                {
                    if (log)
                        IO.Log("Starting at " + pos + " looking at " + direction.ToString() + "\r\nInstruction: " + instruction + "\r\n"); ;


                    int steps = 0;


                    if (instruction.Contains("R"))
                    {
                        steps = int.Parse(instruction.Substring(instruction.IndexOf("R") + 1));


                        direction = Turn("R", direction);

                        if (log)
                            IO.Log("Want to turn R and walk " + steps + " steps\r\nAfter turn now facing " + direction.ToString());
                    }
                    else
                    {
                        steps = int.Parse(instruction.Substring(instruction.IndexOf("L") + 1));



                        direction = Turn("L", direction);

                        if (log)
                            IO.Log("Want to turn L and walk " + steps + " steps\r\nAfter turn now facing " + direction.ToString());
                    }

                    pos = Move(pos, steps, direction);

                    if (log)
                    {
                        IO.Log("\r\nMoved to pos " + pos);
                        IO.Log("-----------------------");
                    }

                }
            }

            if (log)
                IO.WriteLogToFile(false, false);


            return Math.Abs(pos.X) + Math.Abs(pos.Y);
        }



        private static float StepsToFirstRevist(List<string> input)
        {
            List<Vector2> visited = new List<Vector2>();

            Direction direction = Direction.North;
            Vector2 pos = new Vector2(0, 0);

            foreach (string instruction in input)
            {

                if (instruction != "")
                {
                    if (log)
                        IO.Log("Starting at " + pos + " looking at " + direction.ToString() + "\r\nInstruction: " + instruction + "\r\n"); ;


                    int steps = 0;


                    if (instruction.Contains("R"))
                    {
                        steps = int.Parse(instruction.Substring(instruction.IndexOf("R") + 1));


                        direction = Turn("R", direction);

                        if (log)
                            IO.Log("Want to turn R and walk " + steps + " steps\r\nAfter turn now facing " + direction.ToString());
                    }
                    else
                    {
                        steps = int.Parse(instruction.Substring(instruction.IndexOf("L") + 1));



                        direction = Turn("L", direction);

                        if (log)
                            IO.Log("Want to turn L and walk " + steps + " steps\r\nAfter turn now facing " + direction.ToString());
                    }


                    for (int i = 0; i < steps; i++)
                    {
                        pos = Step(pos, direction);

                        foreach (Vector2 place in visited)
                        {
                            if (place.X == pos.X && place.Y == pos.Y)
                            {
                                return Math.Abs(pos.X) + Math.Abs(pos.Y);
                            }
                        }

                        visited.Add(pos);
                    }


                    if (log)
                    {
                        IO.Log("\r\nMoved to pos " + pos);
                        IO.Log("-----------------------");
                    }

                }
            }

            if (log)
                IO.WriteLogToFile(false, false);


            return -1;
        }

        private static Direction Turn(string dir, Direction current)
        {
            if (dir == "R")
            {
                current += 1;

                if (current > Direction.West)
                    current = Direction.North;
            }

            else
            {
                current--;

                if (current < Direction.North)
                    current = Direction.West;
            }

            return current;
        }

        private static Vector2 Move(Vector2 startPos, int steps, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    startPos.Y -= steps;

                    break;

                case Direction.South:
                    startPos.Y += steps;
                    break;

                case Direction.East:
                    startPos.X += steps;
                    break;

                case Direction.West:
                    startPos.X -= steps;
                    break;
            }

            return startPos;
        }

        private static Vector2 Step(Vector2 startPos, Direction direction)
        {
            return Move(startPos, 1, direction);
        }
    }
}
