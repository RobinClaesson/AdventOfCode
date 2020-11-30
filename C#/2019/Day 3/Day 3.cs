using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AoC;
using System.Drawing;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading Input");
            List<string> input = IO.InputRows;
            //List<string> input = Input.GetSeparatedInputList_String('\r');

            //Removes the '\n' from every linebreak
            for (int i = 1; i < input.Count; i++)
                input[i] = input[i].Substring(1);

            Console.WriteLine("Creating Wires");
            List<Wire> wires = new List<Wire>();

            foreach (string path in input)
            {
                string[] steps = path.Split(',');
                Wire wire = new Wire();

                foreach (string step in steps)
                {
                    char direction = step[0];
                    int distance = int.Parse(step.Remove(0, 1));

                    wire.AddPoints(direction, distance);
                }

                wires.Add(wire);
            }

            Console.WriteLine("Finding Intersections");


            Part1(wires);

            IO.Output(wires[0].StepsToIntersection(wires[1]));
            Console.ReadKey();
        }

        private static void Part1(List<Wire> wires)
        {
            List<Point> intersections = new List<Point>();

            intersections.AddRange(FindIntersections(0, wires.Count, wires));

            Console.WriteLine("Finding closest intersection");
            int closest = ManhattanDistance(Point.Empty, intersections[0]);

            for (int i = 1; i < intersections.Count; i++)
            {
                int md = ManhattanDistance(Point.Empty, intersections[i]);

                if (md < closest)
                    closest = md;
            }

            IO.Output(closest);
          
        }

        private static int ManhattanDistance(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }

        private static List<Point> FindIntersections(int startIndex, int endIndex, List<Wire> wires)
        {
            List<Point> intersections = new List<Point>();

            for (int i = startIndex; i < endIndex; i++)
                for (int j = i + 1; j < endIndex; j++)
                {
                    intersections.AddRange(wires[i].FindIntersections(wires[j]));
                }


            return intersections;
        }

    }
}
