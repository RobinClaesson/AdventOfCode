using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Day5
{
    class Day5
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;


            Dictionary<Vector2, int> points1 = new Dictionary<Vector2, int>();
            Dictionary<Vector2, int> points2 = new Dictionary<Vector2, int>();

            foreach (string row in input)
            {
                string[] info = row.Replace(" ", "").Replace("-", "").Split('>');

                string[] startInfo = info[0].Split(',');
                string[] endInfo = info[1].Split(',');

                Vector2 start = new Vector2(int.Parse(startInfo[0]), int.Parse(startInfo[1]));
                Vector2 end = new Vector2(int.Parse(endInfo[0]), int.Parse(endInfo[1]));



                Vector2 step = (end - start);

                if (step.X != 0)
                    step.X /= Math.Abs(step.X);
                if (step.Y != 0)
                    step.Y /= Math.Abs(step.Y);

                Vector2 current = new Vector2(start.X, start.Y);

                if (start.X == end.X || start.Y == end.Y)
                    AddPoint(current, points1);

                AddPoint(current, points2);
                do
                {
                    current += step;

                    if (start.X == end.X || start.Y == end.Y)
                        AddPoint(current, points1);

                    AddPoint(current, points2);
                } while (current != end);


            }

            IO.Output(points1.Count(p => p.Value > 1));
            IO.Output(points2.Count(p => p.Value > 1));
            Console.ReadKey();
        }

        public static void AddPoint(Vector2 point, Dictionary<Vector2, int> points)
        {
            if (!points.Keys.Contains(point))
                points.Add(point, 0);

            points[point] += 1;
        }
    }
}
