using AoC;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part 1
            List<int> input1 = IO.InputSplitted_Int(',');
            List<int> part1 = SparseHash(input1, 1);
            IO.Output(part1[0] * part1[1]);

            //Part 2
            IO.Output(KnotHash(IO.Input), true);
            Console.ReadKey();
        }

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

    }
}
