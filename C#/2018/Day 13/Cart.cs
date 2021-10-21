using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC.Directions;

namespace Day_13
{
    class Cart
    {

        public int X { get; set; }
        public int Y { get; set; }
        public Direction Dir { get; set; }

        private int intersection = 0;

        public Cart(int x, int y, Direction dir)
        {
            X = x;
            Y = y;

            Dir = dir;
        }

        public Cart(int x, int y, char dir)
        {
            X = x;
            Y = y;

            Dir = Direction.Up;

            if (dir == 'v')
                Dir = Direction.Down;
            else if (dir == '<')
                Dir = Direction.Left;
            else if (dir == '>')
                Dir = Direction.Right;
        }

        public void Update(char[,] map)
        {
            //Move
            if (Dir == Direction.Up)
                Y--;
            else if (Dir == Direction.Down)
                Y++;
            else if (Dir == Direction.Left)
                X--;
            else if (Dir == Direction.Right)
                X++;

            //Rotate
            switch (map[Y, X])
            {
                case '/':
                    if (Dir == Direction.Up || Dir == Direction.Down)
                        Dir = Directions.TurnRight(Dir);
                    else 
                        Dir = Directions.TurnLeft(Dir);                    
                    break;

                case '\\':
                    if (Dir == Direction.Up || Dir == Direction.Down)
                        Dir = Directions.TurnLeft(Dir);
                    else 
                        Dir = Directions.TurnRight(Dir);
                    break;

                case '+':

                    if(intersection == 0)
                        Dir = Directions.TurnLeft(Dir);
                    if (intersection == 2)
                        Dir = Directions.TurnRight(Dir);

                    intersection++;
                    intersection %= 3;

                    break;
            }

        }

        public override string ToString()
        {
            switch(Dir)
            {
                default:
                case Direction.Up: return "^";
                case Direction.Down: return "v";
                case Direction.Left: return "<";
                case Direction.Right: return ">";
            }

        }

    }
}
