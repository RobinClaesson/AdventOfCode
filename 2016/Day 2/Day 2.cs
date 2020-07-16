using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;


            IO.Output(Part1(input));

            IO.Output(Part2(input));


            Console.ReadKey();
        }

        private static string Part1(List<string> input)
        {
            int x = 2, y = 1;

            string code = "";

            foreach (string row in input)
            {
                foreach (char c in row)
                {
                    switch (c)
                    {
                        case 'U':

                            if (y > 1)
                                y--;

                            break;

                        case 'D':

                            if (y < 3)
                                y++;

                            break;

                        case 'L':

                            if (x > 1)
                                x--;

                            break;

                        case 'R':

                            if (x < 3)
                                x++;

                            break;

                    }


                }

                code += x + 3 * (y - 1);
            }

            return code;
        }

        private static string Part2(List<string> input)
        {
            char[,] keyPad = new char[5, 5];

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    keyPad[i, j] = 'x';

            keyPad[2, 0] = '1';
            keyPad[1, 1] = '2';
            keyPad[2, 1] = '3';
            keyPad[3, 1] = '4';
            keyPad[0, 2] = '5';
            keyPad[1, 2] = '6';
            keyPad[2, 2] = '7';
            keyPad[3, 2] = '8';
            keyPad[4, 2] = '9';
            keyPad[1, 3] = 'A';
            keyPad[2, 3] = 'B';
            keyPad[3, 3] = 'C';
            keyPad[2, 4] = 'D';


            string code = "";

            int x = 0;
            int y = 2;

            foreach (string row in input)
            {
                foreach (char c in row)
                {
                    switch (c)
                    {
                        case 'U':

                            if (y > 0)
                            {
                                if (keyPad[x, y - 1] != 'x')
                                    y--;
                            }
                               

                            break;

                        case 'D':

                            if(y < 4)
                            {
                                if (keyPad[x, y + 1] != 'x')
                                    y++;
                            }

                            break;

                        case 'L':

                            if (x > 0)
                            {
                                if (keyPad[x-1, y] != 'x')
                                    x--;
                            }

                            break;

                        case 'R':

                            if (x < 4)
                            {
                                if (keyPad[x+1, y] != 'x')
                                    x++;
                            }

                            break;

                    }


                }

                code += keyPad[x,y];
            }




            return code;
        }
    }
}
