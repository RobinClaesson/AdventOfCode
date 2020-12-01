using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
using System.Drawing;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            List<Point>[] wires = new List<Point>[] { new List<Point>(), new List<Point>() };

            wires[0].Add(Point.Empty);
            wires[1].Add(Point.Empty);

            //Creates wires
            for (int i = 0; i < wires.Length; i++)
            {
                string[] moves = input[i].Split(',');

                foreach (string move in moves)
                {
                    char dir = move.First();
                    int dist = int.Parse(move.Substring(1));

                    for (int j = 0; j < dist; j++)
                    {
                        Point last = wires[i].Last();
                        switch (dir)
                        {
                            default:
                            case 'U':
                                wires[i].Add(new Point(last.X, last.Y + 1));
                                break;

                            case 'D':
                                wires[i].Add(new Point(last.X, last.Y - 1));
                                break;

                            case 'R':
                                wires[i].Add(new Point(last.X + 1, last.Y));
                                break;

                            case 'L':
                                wires[i].Add(new Point(last.X - 1, last.Y));
                                break;
                        }
                    }
                }
            }

            //Finding intersections between wires
            List<Point> intersections = new List<Point>();
            double counter = 1, lastDone = 0;
            foreach (Point w1 in wires[0])
            {

                foreach (Point w2 in wires[1])
                {
                    if (w1.Equals(w2) && !w1.Equals(Point.Empty))
                        intersections.Add(w1);
                }

                double done = Math.Round((counter / wires[0].Count) * 100, 0);
                if (done != lastDone)
                {
                    Console.Clear();
                    Console.WriteLine("Finding intersections {0}%", done);
                    lastDone = done;
                }
                counter++;
            }


            //Finding answers
            int closestDist = ManhattanDistToStart(intersections[0]);
            int fewestSteps = StepsToIntersection(wires, intersections[0]);
            for (int i = 1; i < intersections.Count; i++)
            {
                int dist = ManhattanDistToStart(intersections[i]);

                if (dist < closestDist)
                    closestDist = dist;

                int steps = StepsToIntersection(wires, intersections[i]);

                if (steps < fewestSteps)
                    fewestSteps = steps;
            }


            IO.Output(closestDist);
            IO.Output(fewestSteps);
        }

        private static int ManhattanDist(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }

        private static int ManhattanDistToStart(Point p)
        {
            return ManhattanDist(p, Point.Empty);
        }

        private static int StepsToIntersection(List<Point>[] wires, Point intersection)
        {
            return wires[0].IndexOf(intersection) + wires[1].IndexOf(intersection);
        }
    }
}
