using AoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace Day_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = IO.Input;

            int bitCount = 0;
            int[,] bits = new int[128, 128];

            //Adding all the bits and counting them
            for (int y = 0; y < 128; y++)
            {
                string hash = KnotHash(input + "-" + y);

                //https://stackoverflow.com/questions/6617284/c-sharp-how-convert-large-hex-string-to-binary
                string binarystring = String.Join(String.Empty, hash.Select(c => Convert.ToString(
                                       Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));


                for (int x = 0; x < binarystring.Length; x++)
                {
                    if (binarystring[x] == '1')
                    {
                        bitCount++;


                        bits[y, x] = bitCount;

                    }
                }
            }


            //Sorts everything into groups
            int groups = 0;
            Queue<Point> queue = new Queue<Point>();
            HashSet<Point> seen = new HashSet<Point>();

            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    Point pos = new Point(x, y);

                    if (!seen.Contains(pos) && bits[y, x] != 0)
                    {
                        groups++;
                        bits[y, x] = groups;
                        queue.Enqueue(pos);
                        seen.Add(pos);

                        while (queue.Count > 0)
                        {
                            Point p = queue.Dequeue();
                            foreach (Point n in Helper.PointNeighbours(p))
                            {
                                if (!seen.Contains(n) && n.X >= 0 && n.X < 128 && n.Y >= 0 && n.Y < 128 && bits[n.Y, n.X] != 0)
                                {
                                    bits[n.Y, n.X] = groups;
                                    queue.Enqueue(n);
                                    seen.Add(n);
                                }
                            }
                        }


                    }
                }
            }


            IO.Output(bitCount);
            IO.Output(groups);


            //DebugPrint
            //for (int y = 0; y < 10; y++)
            //{
            //    for (int x = 0; x < 10; x++)

            //    {
            //        Point v = new Point(x, y);

            //        if (bits[y, x] != 0)
            //            Console.Write(bits[y, x] + "\t");
            //        else
            //            Console.Write("#\t");
            //    }
            //    Console.WriteLine();
            //}


            Console.ReadKey();
        }


        //FROM AoC 2017 day 10
        //------------------------------------------------------------------
        static List<int> SparseHash(List<int> lengths, int rounds)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 256; i++)
                list.Add(i);

            int index = 0, skipSize = 0;
            for (int round = 0; round < rounds; round++)
                foreach (int length in lengths)
                {
                    List<int> toTwist = new List<int>();

                    //Creates the list in reverse
                    for (int i = index; i < index + length; i++)
                    {
                        if (i >= list.Count)
                            toTwist.Insert(0, list[i - list.Count]);
                        else
                            toTwist.Insert(0, list[i]);
                    }

                    //Puts it back in its new order
                    for (int i = 0; i < length; i++)
                    {
                        if (index + i >= list.Count)
                            list[index + i - list.Count] = toTwist[i];
                        else
                            list[index + i] = toTwist[i];
                    }

                    index += length + skipSize;
                    while (index > list.Count)
                        index -= list.Count;

                    skipSize++;
                }

            return list;
        }

        static List<int> LengthsFromString(string input)
        {
            List<char> inputAsChar = input.ToList();
            List<int> lengths = new List<int>();
            foreach (char c in inputAsChar)
                lengths.Add((int)c);

            lengths.AddRange(new int[] { 17, 31, 73, 47, 23 });
            return lengths;
        }

        static string KnotHash(string toHash)
        {
            List<int> sparseHash = SparseHash(LengthsFromString(toHash), 64);

            List<int> denseHash = new List<int>();
            for (int i = 0; i < sparseHash.Count; i += 16)
            {
                int xor = sparseHash[i];

                for (int j = 1; j < 16; j++)
                    xor = xor ^ sparseHash[i + j];

                denseHash.Add(xor);
            }

            string hash = "";

            for (int i = 0; i < denseHash.Count; i++)
            {
                string hex = denseHash[i].ToString("x");

                if (hex.Length == 1)
                    hex = "0" + hex;

                hash += hex;
            }


            return hash;
        }
        //-----------------------------------------------------------------
    }
}
