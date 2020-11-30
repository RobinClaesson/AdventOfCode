using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using AoC;
using System.ComponentModel.Design;
using System.Collections;
using System.Net.Http.Headers;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = IO.Input_Int;
            //Part 1
            IO.Output(StepsToTarget(input));

            //Part 2
            IO.Output(FirstLargerThan(input));
            Console.ReadKey();
        }

        private static int StepsToTarget(int lastValue, int rectSize, Vector2 posOfLast, int target)
        {
            //Calculating first manualy
            int value = lastValue + 1;
            Vector2 pos = posOfLast + new Vector2(1, 0);

            if (value == target)
                return (int)(Math.Abs(pos.X) + Math.Abs(pos.Y));

            //Steps up
            for (int i = 1; i < rectSize - 1; i++)
            {
                value++;
                pos.Y--;

                if (value == target)
                    return (int)(Math.Abs(pos.X) + Math.Abs(pos.Y));
            }

            //Steps Left
            for (int i = 0; i < rectSize - 1; i++)
            {
                value++;
                pos.X--;

                if (value == target)
                    return (int)(Math.Abs(pos.X) + Math.Abs(pos.Y));
            }

            //Steps Down
            for (int i = 0; i < rectSize - 1; i++)
            {
                value++;
                pos.Y++;

                if (value == target)
                    return (int)(Math.Abs(pos.X) + Math.Abs(pos.Y));
            }

            //Steps Right
            for (int i = 0; i < rectSize - 1; i++)
            {
                value++;
                pos.X++;

                if (value == target)
                    return (int)(Math.Abs(pos.X) + Math.Abs(pos.Y));
            }

            //If we havent found target we look in next square
            return StepsToTarget(value, rectSize + 2, pos, target);

        }

        private static int StepsToTarget(int target)
        {
            if (target == 1)
                return 0;
            else return StepsToTarget(1, 3, new Vector2(0, 0), target);
        }


        private static int FirstLargerThan(int target)
        {
            if (target == 0)
                return 1;

            Vector2 pos = new Vector2(0, 0);
            Hashtable values = new Hashtable();
            values.Add(pos, 1);

            return FirstLargerThan(values, 3, pos, target);
        }

        private static int FirstLargerThan(Hashtable values, int rectSize, Vector2 posOfLast, int target)
        {
            //First one manualy
            Vector2 pos = posOfLast + new Vector2(1, 0);
            int value = 0;

            foreach(Vector2 n in Neighbours(pos))
            {
                if (values.ContainsKey(n))
                    value += (int)values[n];
            }

            if (value > target)
                return value;
            else
                values.Add(pos, value);

            //Steps up
            for(int i = 1; i < rectSize-1; i++)
            {
                pos.Y--;
                value = 0;

                foreach (Vector2 n in Neighbours(pos))
                {
                    if (values.ContainsKey(n))
                        value += (int)values[n];
                }

                if (value > target)
                    return value;
                else
                    values.Add(pos, value);
            }

            //Steps left
            for (int i = 0; i < rectSize - 1; i++)
            {
                pos.X--;
                value = 0;

                foreach (Vector2 n in Neighbours(pos))
                {
                    if (values.ContainsKey(n))
                        value += (int)values[n];
                }

                if (value > target)
                    return value;
                else
                    values.Add(pos, value);
            }

            //Steps down
            for (int i = 0; i < rectSize - 1; i++)
            {
                pos.Y++;
                value = 0;

                foreach (Vector2 n in Neighbours(pos))
                {
                    if (values.ContainsKey(n))
                        value += (int)values[n];
                }

                if (value > target)
                    return value;
                else
                    values.Add(pos, value);
            }

            //Steps right
            for (int i = 0; i < rectSize - 1; i++)
            {
                pos.X++;
                value = 0;

                foreach (Vector2 n in Neighbours(pos))
                {
                    if (values.ContainsKey(n))
                        value += (int)values[n];
                }

                if (value > target)
                    return value;
                else
                    values.Add(pos, value);
            }


            return FirstLargerThan(values, rectSize + 2, pos, target);
        }


        public static Vector2[] Neighbours(Vector2 pos)
        {
            List<Vector2> neighbours = new List<Vector2>();

            neighbours.Add(new Vector2(1, 0) + pos);
            neighbours.Add(new Vector2(1, 1) + pos);
            neighbours.Add(new Vector2(0, 1) + pos);
            neighbours.Add(new Vector2(-1, 1) + pos);
            neighbours.Add(new Vector2(-1, 0) + pos);
            neighbours.Add(new Vector2(-1, -1) + pos);
            neighbours.Add(new Vector2(0, -1) + pos);
            neighbours.Add(new Vector2(1, -1) + pos);

            return neighbours.ToArray();
        }
    }
}
