using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string input = IO.Input;
            MD5 md5hash = MD5.Create();

            //Part 1
            int i = 0;
            string hash = "";
            do
            {
                i++;
                hash = MD5Hash(input + i, md5hash);
            } while (hash.Substring(0, 5) != "00000");


            IO.Output(i);


            //Part 2
            i = 0;
            do
            {
                i++;
                hash = MD5Hash(input + i, md5hash);
            } while (hash.Substring(0, 6) != "000000");

            IO.Output(i);


            Console.ReadKey();
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
    }
}
