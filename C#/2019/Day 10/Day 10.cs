using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
using Microsoft.Xna.Framework;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> input = Input.GetInputList_String;
            List<string> input = IO.InputRows;
            Point mapSize = new Point(input[0].Length, input.Count);

            //Finetuned with examples
            float delta_f = 0.000001f;


            List<Vector2> asteroids = new List<Vector2>();

            for (int y = 0; y < mapSize.Y; y++)
            {
                for (int x = 0; x < mapSize.X; x++)
                {
                    if (input[y][x] == '#')
                    {
                        asteroids.Add(new Vector2(x, y));
                    }
                }
            }

            //Part 1
            Console.WriteLine("Part 1");
            int maxViews = int.MinValue;
            Vector2 basePos = Vector2.Zero;

            foreach (Vector2 asteroid in asteroids)
            {
                List<Vector2> directions = new List<Vector2>();

                foreach (Vector2 other in asteroids)
                {
                    if (other != asteroid)
                    {
                        Vector2 newDir = (other - asteroid);
                        newDir.Normalize();

                        bool oldDirection = false;

                        foreach (Vector2 dir in directions)
                            if (Math.Abs(dir.X - newDir.X) < delta_f && Math.Abs(dir.Y - newDir.Y) < delta_f)
                                oldDirection = true;

                        if (!oldDirection)
                            directions.Add(newDir);

                    }
                }

                if (directions.Count > maxViews)
                {
                    maxViews = directions.Count;
                    basePos = asteroid;
                }

            }

            IO.Output(maxViews + " at " + basePos);


            //Part 2
            Console.WriteLine("Part 2");

            asteroids.RemoveAt(asteroids.IndexOf(basePos));

            int destroyed = 0;

            List<Vector2> laserDirs = new List<Vector2>();
            for (int i = 1; i <= 360; i++)
            {
                laserDirs.Add(new Vector2((float)Math.Cos(((Math.PI * 2) / i) + (3 * Math.PI / 2)), (float)Math.Sin(((Math.PI * 2) / i) + (3 * Math.PI / 2))));
            }

            
            Console.ReadKey();
        }




    }
}
