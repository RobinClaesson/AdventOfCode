using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC_IO;
using System.Drawing;
using System.Diagnostics;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Input.GetInput_String;
            Point imageSize = new Point(25, 6);
            
            Part1(input, imageSize);

            //Part 2
            Console.WriteLine("Part 2");
            int[,] imageGraph = new int[imageSize.Y, imageSize.X];

            for (int y = 0; y < imageSize.Y; y++)
                for (int x = 0; x < imageSize.X; x++)
                    imageGraph[y, x] = 2;

            for (int i = 0; i < input.Length; i++)
            {
                Point pos = new Point((i % imageSize.X), (i / imageSize.X) % imageSize.Y);

                if (imageGraph[pos.Y, pos.X] == 2)
                    imageGraph[pos.Y, pos.X] = int.Parse("" + input[i]);

            }

            Bitmap image = new Bitmap(imageSize.X, imageSize.Y);
            //Print image
            for (int y = 0; y < imageSize.Y; y++)
            {
                for (int x = 0; x < imageSize.X; x++)
                {
                    if (imageGraph[y, x] == 2)
                    {
                        Console.Write(" ");
                        image.SetPixel(x, y, Color.Transparent);
                    }
                    else if (imageGraph[y, x] == 1)
                    {
                        Console.Write("#");
                        image.SetPixel(x, y, Color.White);
                    }
                    else if (imageGraph[y, x] == 0)
                    {
                        Console.Write(".");
                        image.SetPixel(x, y, Color.Black);
                    }
                }
                Console.WriteLine();
            }


            image.Save("Image.png", System.Drawing.Imaging.ImageFormat.Png);

            Process.Start("Image.png");


            Console.ReadKey();
        }

        private static void Part1(string input, Point imageSize)
        {
            Console.WriteLine("Part 1");
            int fewestZeroes = int.MaxValue;
            int ones = 0, twos = 0;

            for (int i = 0; i < input.Length; i += imageSize.X * imageSize.Y)
            {
                string layer = input.Substring(i, imageSize.X * imageSize.Y);

                //Counts the number of zeros in layer
                int zeros = layer.Count(f => f == '0');

                if (zeros < fewestZeroes)
                {
                    fewestZeroes = zeros;
                    ones = layer.Count(f => f == '1');
                    twos = layer.Count(f => f == '2');
                }
            }


            Output.PresentAnswer(ones * twos);
        }
    }
}
