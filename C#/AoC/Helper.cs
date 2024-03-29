﻿using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace AoC
{
    public class Helper
    {
        public static int Min(int[] numbers)
        {

            int min = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
            }

            return min;
        }

        public static int Max(int[] numbers)
        {

            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i];
            }

            return max;
        }


        public static string MD5Hash(string input, MD5 md5Hash)
        {


            //https://coderwall.com/p/4puszg/c-convert-string-to-md5-hash
            //https://www.reddit.com/r/adventofcode/comments/3vdn8a/day_4_solutions/cxmt6yp?utm_source=share&utm_medium=web2x

            StringBuilder hash = new StringBuilder();
            //MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5Hash.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }


        public static List<List<T>> EveryCombinationOfItems<T>(List<T> source, int numOfItems, bool considerOrder)
        {
            List<List<T>> items = new List<List<T>>();

            if (numOfItems == 0)
                return items;


            if (numOfItems == 1)
            {
                foreach (T t in source)
                    items.Add(new List<T>() { t });
            }


            else
                foreach (T item in source)
                {
                    List<T> witoutCurrent = new List<T>();
                    witoutCurrent.AddRange(source);
                    witoutCurrent.Remove(item);

                    List<List<T>> recursions = EveryCombinationOfItems(witoutCurrent, numOfItems - 1, considerOrder);

                    foreach (List<T> recursion in recursions)
                    {

                        //Adds the current item
                        recursion.Insert(0, item);

                        if (considerOrder)
                            items.Add(recursion);

                        else
                        {
                            bool hasList = false;

                            foreach (List<T> list in items)
                            {
                                if (list.All(recursion.Contains))
                                    hasList = true;
                            }

                            if (!hasList)
                                items.Add(recursion);
                        }
                    }


                }


            return items;
        }


        public static Point[] PointNeighbours(Point pos)
        {
            return new Point[] {new Point(pos.X+1, pos.Y), new Point(pos.X,pos.Y+1),
                                new Point(pos.X-1, pos.Y), new Point(pos.X, pos.Y-1)};
        }

        static DateTime lastProgress = DateTime.Now;
        public static void PrintProgress(bool clear, int completed, int goal, int precision)
        {
            precision *= 100;

            if (goal > precision)
                if (completed % (goal / precision) == 0)
                {
                    if (clear)
                        Console.Clear();


                    TimeSpan sinceLast = DateTime.Now - lastProgress;
                    double progressDone = (double)completed / (double)(goal / 100);
                    double progressLeft = 100 - progressDone;
                    double stepsLeft = progressLeft * precision / 100;

                    Console.WriteLine("Round {1}/{2} = {0}% Done. ", progressDone, completed, goal);
                    lastProgress = DateTime.Now;

                }
        }

    }

}

