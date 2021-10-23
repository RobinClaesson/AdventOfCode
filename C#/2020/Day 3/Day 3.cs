using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            int mapWidth = input[0].Length;
            int mapHeight = input.Count;

            char[][] map = new char[mapHeight][];

            for (int i = 0; i < map.Length; i++)
                map[i] = input[i].ToCharArray();

            Point2[] moves = new Point2[] { new Point2(3, 1), new Point2(1, 1), new Point2(5, 1), new Point2(7, 1), new Point2(1, 2) };
            int[] hits = new int[moves.Length];

            for (int i = 0; i < moves.Length; i++)
            {
                Point2 pos = Point2.Zero;

                do
                {
                    if (map[pos.Y][pos.X] == '#')
                        hits[i]++;

                    pos += moves[i];

                    if (pos.X >= mapWidth)
                        pos.X %= mapWidth;

                    
                } while (pos.Y < mapHeight);
            }

            IO.Output(hits[0]);

            long productOfhits = 1;
            foreach (int h in hits)
                productOfhits *= h;

            IO.Output(productOfhits);

            Console.ReadKey();

        }
    }
}
