using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Day_3
{
    class Wire
    {
        
        List<Point> _points = new List<Point>();
        public List<Point> Points { get { return _points; } }


        public Wire()
        {
            _points.Add(Point.Empty);
        }

        public void AddPoints(char direction, int distance)
        {
            for (int i = 0; i < distance; i++)
            {


                if (direction == 'U')
                {
                    _points.Add(new Point(_points[_points.Count - 1].X, _points[_points.Count - 1].Y + 1));
                }

                else if (direction == 'D')
                {
                    _points.Add(new Point(_points[_points.Count - 1].X, _points[_points.Count - 1].Y - 1));
                }

                else if (direction == 'R')
                {
                    _points.Add(new Point(_points[_points.Count - 1].X + 1, _points[_points.Count - 1].Y));
                }

                else if (direction == 'L')
                {
                    _points.Add(new Point(_points[_points.Count - 1].X - 1, _points[_points.Count - 1].Y));
                }
            }

        }

        static long counter = 0;
        public List<Point> FindIntersections(Wire other)
        {


            List<Point> intersections = new List<Point>();

            foreach (Point p1 in Points)
                foreach (Point p2 in other.Points)
                {
                    if (p1 == p2 && p1 != Point.Empty)
                        intersections.Add(p1);
                    counter++;

                    if (counter % 100000000 == 0)
                    {
                        Console.WriteLine(counter + "\n\r" + "23051686224\r\n-----");
                    }
                }

            return intersections;
        }

        public int StepsToIntersection(Wire other)
        {
            int steps = int.MaxValue;

            for(int i = 0; i < Points.Count; i++)
                for(int j = 0; j < other.Points.Count; j++ )
                {
                    if (Points[i] == other.Points[j] && Points[i] != Point.Empty)
                        if ((i + j) < steps)
                            steps = i + j;


                    counter++;

                    if (counter % 100000000 == 0)
                    {
                        Console.WriteLine(counter + "\n\r" + "23051686224\r\n-----");
                    }
                }
            return steps;
        }


    }
}
