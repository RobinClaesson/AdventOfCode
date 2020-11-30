using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> input = IO.InputRows;


            int size = 1000;
            bool[,] lights = new bool[size, size];

            //Part 1
            foreach(string row in input)
            {
                string[] words = row.Split(' ');

                if(words[0] == "turn")
                {
                    string[] startPos = words[2].Split(',');
                    int startX = int.Parse(startPos[0]);
                    int startY = int.Parse(startPos[1]);

                    string[] endPos = words[4].Split(',');
                    int stopX = int.Parse(endPos[0]);
                    int stopY = int.Parse(endPos[1]);

                    Turn(startX, startY, stopX, stopY, (words[1] == "on"), lights);
                }

                else
                {
                    string[] startPos = words[1].Split(',');
                    int startX = int.Parse(startPos[0]);
                    int startY = int.Parse(startPos[1]);

                    string[] endPos = words[3].Split(',');
                    int stopX = int.Parse(endPos[0]);
                    int stopY = int.Parse(endPos[1]);

                    Toggle(startX, startY, stopX, stopY, lights);
                }
            }

            int lightsOn = 0;

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (lights[x, y])
                        lightsOn++;

            IO.Output(lightsOn);

            //Part 2
            int[,] dimmerd = new int[size, size];

            foreach(string row in input)
            {
                string[] words = row.Split(' ');

                if (words[0] == "turn")
                {
                    string[] startPos = words[2].Split(',');
                    int startX = int.Parse(startPos[0]);
                    int startY = int.Parse(startPos[1]);

                    string[] endPos = words[4].Split(',');
                    int stopX = int.Parse(endPos[0]);
                    int stopY = int.Parse(endPos[1]);

                    if (words[1] == "on")
                        Dimmer(startX, startY, stopX, stopY, 1, dimmerd);
                    else
                        Dimmer(startX, startY, stopX, stopY, -1, dimmerd);
                }

                else
                {
                    string[] startPos = words[1].Split(',');
                    int startX = int.Parse(startPos[0]);
                    int startY = int.Parse(startPos[1]);

                    string[] endPos = words[3].Split(',');
                    int stopX = int.Parse(endPos[0]);
                    int stopY = int.Parse(endPos[1]);

                    Dimmer(startX, startY, stopX, stopY, 2, dimmerd);
                }
            }

            int brightness = 0;

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    brightness += dimmerd[x, y];

            IO.Output(brightness, true);

            Console.ReadKey();
        }

        static void Turn(int startX, int startY, int stopX, int stopY, bool value, bool[,] lights)
        {
            for(int x = startX; x <= stopX; x++)
                for(int y = startY; y<= stopY; y++)
                {
                    lights[x, y] = value;
                }
        }

        static void Toggle(int startX, int startY, int stopX, int stopY, bool[,] lights)
        {
            for (int x = startX; x <= stopX; x++)
                for (int y = startY; y <= stopY; y++)
                {
                    lights[x, y] = !lights[x,y];
                }
        }

        static void Dimmer(int startX, int startY, int stopX, int stopY, int value, int[,] lights)
        {
            for (int x = startX; x <= stopX; x++)
                for (int y = startY; y <= stopY; y++)
                {
                    lights[x, y] += value;

                    if (lights[x, y] < 0)
                        lights[x, y] = 0;
                }
        }
    }
}
