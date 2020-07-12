using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Day_3_2015
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = IO.Input;

            //Part 1
            Point pos = new Point(0, 0);
            List<Point> houses = new List<Point>();
            houses.Add(pos);

            foreach(char c in input)
            {
                switch(c)
                {
                    case '<':
                        pos.X--;
                        break;
                    case '>':
                        pos.X++;
                        break;
                    case '^':
                        pos.Y--;
                        break;
                    case 'v':
                        pos.Y++;
                        break;

                }

                if (!houses.Contains(pos))
                    houses.Add(pos);
            }

            IO.Output(houses.Count, 1);

            //Part 2
            Point[] positions = new Point[] { new Point(0, 0), new Point(0, 0) };
            houses.Clear();
            houses.Add(positions[0]);

            for(int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '<':
                        positions[i%2].X--;
                        break;
                    case '>':
                        positions[i % 2].X++;
                        break;
                    case '^':
                        positions[i % 2].Y--;
                        break;
                    case 'v':
                        positions[i % 2].Y++;
                        break;
                }

                if (!houses.Contains(positions[i % 2]))
                    houses.Add(positions[i % 2]);

            }

            IO.Output(houses.Count, 2);

            Console.ReadKey();
        }
    }
}
