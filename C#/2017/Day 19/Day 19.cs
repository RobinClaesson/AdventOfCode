using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
using System.Drawing;

namespace Day_19
{
    class Program
    {
        enum Direction { U, D, R, L };
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            Point pos = Point.Empty;
            Direction dir = Direction.D;

            string visitedLetters = "";

            //Finding startpos
            for (int i = 0; i < input.Count; i++)
                if (input[0][i] != ' ')
                    pos.X = i;

            int steps = 0;
            while (input[pos.Y][pos.X] != ' ')
            {
                steps++;
                //Moves in the direction
                switch (dir)
                {
                    default:
                    case Direction.D:
                        pos.Y++;
                        break;

                    case Direction.U:
                        pos.Y--;
                        break;

                    case Direction.R:
                        pos.X++;
                        break;

                    case Direction.L:
                        pos.X--;
                        break;
                }

                //Adds letters                
                if (input[pos.Y][pos.X] >= 'A' && input[pos.Y][pos.X] <= 'Z')
                    visitedLetters += input[pos.Y][pos.X];


                //Finds new direction
                else if(input[pos.Y][pos.X] == '+')
                {
                    if(dir == Direction.D || dir == Direction.U)
                    {
                        if (input[pos.Y][pos.X - 1] != ' ')
                            dir = Direction.L;
                        else
                            dir = Direction.R;
                    }

                    else
                    {
                        if (input[pos.Y-1][pos.X ] != ' ')
                            dir = Direction.U;
                        else
                            dir = Direction.D;
                    }
                }

            }


            IO.Output(visitedLetters);
            IO.Output(steps, true);
            Console.ReadKey();
        }
    }
}
