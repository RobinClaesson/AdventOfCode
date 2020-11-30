using AoC;
using AoC.Hexgrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputSplitted(',');

            Vector2 pos = Vector2.Zero;
            int furthest = 0;
            foreach (string step in input)
            {
                if (step == "n")
                    pos = HexMovement.Step(pos, HexDirection.North);

                else if (step == "ne")
                    pos = HexMovement.Step(pos, HexDirection.NorthEast);

                else if (step == "se")
                    pos = HexMovement.Step(pos, HexDirection.SouthEast);

                else if (step == "s")
                    pos = HexMovement.Step(pos, HexDirection.South);

                else if (step == "sw")
                    pos = HexMovement.Step(pos, HexDirection.SouthWest);

                else if (step == "nw")
                    pos = HexMovement.Step(pos, HexDirection.NorthWest);


                int dist = HexMovement.Distance(Vector2.Zero, pos);
                if (dist > furthest)
                    furthest = dist;
            }

            IO.Output(HexMovement.Distance(Vector2.Zero, pos));
            IO.Output(furthest);

            Console.ReadKey();
        }
    }
}
