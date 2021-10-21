using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;


namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            //input = 7989
            int input = 7989;

            int[,] powerRack = new int[301, 301];
            //Create power levels
            for (int y = 1; y <= 300; y++)
            {
                for (int x = 1; x <= 300; x++)
                {

                    int id = x + 10;
                    int power = id * y + input;
                    power *= id;

                    power /= 100; //Remove first to digits
                    power %= 10; //Keep only first digit

                    power -= 5;

                    powerRack[y, x] = power;
                }
            }

            //Check largest 3x3 sum, Part1
            Point posOfMax = new Point(-1, -1);
            int max = int.MinValue;

            for (int y = 1; y <= 297; y++)
            {
                for (int x = 1; x <= 297; x++)
                {
                    int sum = 0;
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            sum += powerRack[y + i, x + j];

                    if (sum > max)
                    {
                        max = sum;
                        posOfMax = new Point(x, y);
                    }
                }
            }

            IO.Output(posOfMax.X + "," + posOfMax.Y);

            //Part 2
            posOfMax = new Point(-1, -1);
            max = int.MinValue;
            int sizeOfMax = -1;
            for (int y = 1; y <= 300; y++)
            {
                for (int x = 1; x <= 300; x++)
                {
                    int sum = 0;

                    for (int s = 1; s + Math.Max(x, y) <= 300; s++)
                    {
                        for (int i = 0; i < s; i++)
                            sum += powerRack[y + s - 1, x + i];

                        for (int i = 0; i < s - 1; i++)
                            sum += powerRack[y + i, x + s - 1];

                        if (sum > max)
                        {
                            max = sum;
                            posOfMax = new Point(x, y);
                            sizeOfMax = s;
                        }
                    }
                }
            }

            IO.Output(posOfMax.X + "," + posOfMax.Y + "," + sizeOfMax);
            Console.ReadKey();
        }

        private static void PrintPower(int x, int y, int[,] powerRack)
        {
            Console.WriteLine("Power at " + x + "," + y + ": " + powerRack[y, x]);
        }
    }
}
