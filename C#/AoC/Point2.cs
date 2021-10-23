using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    public class Point2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2()
        {
            X = 0;
            Y = 0;
        }

        public Point2(int xy)
        {
            X = xy;
            Y = xy;
        }
        
        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point2(Point2 p)
        {
            X = p.X;
            Y = p.Y;
        }

        public static Point2 operator +(Point2 a, Point2 b)
        {
            return new Point2(a.X + b.X, a.Y + b.Y);
        }

        public static Point2 operator -(Point2 a, Point2 b)
        {
            return new Point2(a.X - b.X, a.Y - b.Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public static Point2 Zero { get { return new Point2(); } }
    }


}
