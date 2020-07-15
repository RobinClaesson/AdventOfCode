using AoC;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day_25
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputSplitted(' ');

            int targetY= int.Parse(input[16].Substring(0, input[16].IndexOf(',')));
            int targetX = int.Parse(input[18].Substring(0, input[18].IndexOf('.')));

            //int targetX = 6;
            //int targetY = 4;

            int size = (2 * Math.Max(targetX, targetY) - 1);


            long[,] codes = new long[size + 2, size + 2];
            codes[1, 1] = 20151125;

            int lastX = 1, lastY = 1;

            for (int i = 2; i < ((size * size) / 2) + size; i++)
            {
                int x, y;

                if (lastY == 1)
                {
                    y = lastY + lastX;
                    x = 1;
                }

                else
                {
                    y = lastY - 1;
                    x = lastX + 1;
                }

                long lastCode = codes[lastY, lastX];
                long code = codes[lastY, lastX] * 252533;
                code = code % 33554393;

                codes[y, x] = code;
                lastY = y;
                lastX = x;
            }

            //IO.Log(ListCodeCoardinates(codes, size));
            //IO.WriteLogToFile(false, true);

            IO.Output(codes[targetY, targetX], true);
            Console.ReadKey();

        }


        private static string PrintCodes(long[,] codes, int size)
        {
            string s = "";
            for (int y = 1; y <= size; y++)
            {
                for (int x = 0; x <= size; x++)
                {
                    if (codes[y, x] != 0)
                    {
                        string format = "" + codes[y, x];
                        while (format.Length < 8)
                            format += " ";

                        s += format + "\t";
                    }

                }
                s += "\r\n";
            }

            return s;
        }

        private static string ListCodeCoardinates(long[,] codes, int size)
        {
            string s = "";
            for (int y = 1; y <= size; y++)
            {
                for (int x = 0; x <= size; x++)
                {
                    if (codes[y, x] != 0)
                    {
                       
                        s += "Y:" + y + "|X:" + x + "|Code:" + codes[y, x] + "\r\n";
                    }

                }
                            }

            return s;
        }
    }
}
