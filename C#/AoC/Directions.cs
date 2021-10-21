using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Directions
{
    public enum Direction { Up, Right, Down, Left};

    public class Directions
    {
        public static Direction TurnRight(Direction currentDir)
        {
            currentDir++;

            if (currentDir > Direction.Left)
                currentDir = Direction.Up;

            return currentDir;
        }
        public static Direction TurnLeft(Direction currentDir)
        {
            currentDir--;

            if (currentDir < Direction.Up)
                currentDir = Direction.Left;

            return currentDir;
        }
    }
}
