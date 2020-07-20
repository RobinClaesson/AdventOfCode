using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ComponentModel;
using System.Threading;

namespace AoC.Hexgrid
{
    public enum HexDirection { North, NorthEast, SouthEast, South, SouthWest, NorthWest }
    public class HexMovement
    {
        //http://3dmdesign.com/development/hexmap-coordinates-the-easy-way

        //For movements in a Flattop hexgrid coardinate system

        public static Vector2 Move(Vector2 pos, HexDirection dir, int steps)
        {
            switch (dir)
            {
                case HexDirection.North:
                    pos.Y += steps;
                    break;

                case HexDirection.NorthEast:
                    pos.X += steps;
                    pos.Y += steps;
                    break;

                case HexDirection.SouthEast:
                    pos.X += steps;
                    break;

                case HexDirection.South:
                    pos.Y -= steps;
                    break;

                case HexDirection.SouthWest:
                    pos.X -= steps;
                    pos.Y -= steps;
                    break;

                case HexDirection.NorthWest:
                    pos.X -= steps;
                    break;
            }

            return pos;
        }

        public static Vector2 Step(Vector2 pos, HexDirection dir)
        {
            return Move(pos, dir, 1);
        }
                

        public static List<Vector2> Neighbours(Vector2 pos)
        {
            List<Vector2> n = new List<Vector2>();

            n.Add(pos + new Vector2(0, 1)); //North
            n.Add(pos + new Vector2(1, 1)); // North East
            n.Add(pos + new Vector2(1, 0)); // South East

            n.Add(pos + new Vector2(0, -1)); // South
            n.Add(pos + new Vector2(-1, -1)); // South West
            n.Add(pos + new Vector2(-1, 0)); // North West

            return n;
        }


        public static int Distance(Vector2 pos1, Vector2 pos2)
        {
            float dX = pos1.X - pos2.X;
            float dY = pos1.Y - pos2.Y;

            float dD = dY - dX;

            return (int)(Math.Max(Math.Abs(dD), Math.Max(Math.Abs(dY), Math.Abs(dX))));
        }
    }
}
