using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

    }
}
