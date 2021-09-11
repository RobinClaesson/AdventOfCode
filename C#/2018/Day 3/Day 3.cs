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
            List<string[]> input = IO.InputRowsSplitted(' ');

            int[,] claims = new int[1000, 1000];

            foreach (string[] row in input)
            {
                string[] cords = row[2].Split(',');
                int x = int.Parse(cords[0]);
                int y = int.Parse(cords[1].Substring(0, cords[1].Length - 1));

                string[] size = row[3].Split('x');
                int width = int.Parse(size[0]);
                int height = int.Parse(size[1]);

                for(int i = y; i < y+height; i++)
                {
                    for(int j = x; j < x+width; j++)
                    {
                        claims[i, j]++;
                    }
                }
            }

            //Part1
            int answer1 = 0;
            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                    if (claims[i, j] > 1)
                        answer1++;

            IO.Output(answer1);

            //Part2
            int answer2 = -1;
            foreach (string[] row in input)
            {
                if (answer2 == -1)
                {
                    bool correct = true;

                    string[] cords = row[2].Split(',');
                    int x = int.Parse(cords[0]);
                    int y = int.Parse(cords[1].Substring(0, cords[1].Length - 1));

                    string[] size = row[3].Split('x');
                    int width = int.Parse(size[0]);
                    int height = int.Parse(size[1]);

                    for (int i = y; i < y + height; i++)
                    {
                        for (int j = x; j < x + width; j++)
                        {
                            if (claims[i, j] > 1)
                                correct = false;
                        }
                    }

                    if (correct)
                        answer2 = int.Parse(row[0].Substring(1));
                }
            }

            IO.Output(answer2);
            Console.ReadKey();
        }
    }
}
