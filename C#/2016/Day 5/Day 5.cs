using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = IO.Input;


            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();


            int passwordLength = 8;
            string password1 = "";
            char[] password2 = "--------".ToCharArray();

            //Part 1
            int i = 0;

            Console.WriteLine("Finding password 1: 0/" + passwordLength);
            while (password1.Length < passwordLength)
            {
                string hash = Helper.MD5Hash(input + i, md5Hash);

                if (hash.Substring(0, 5) == "00000")
                {
                    password1 += hash[5];

                    Console.WriteLine("Finding password 1: " + password1.Length + "/" + passwordLength);
                }

                i++;
            }

            //Part 2
            i = 0;
            int found = 0;
            Console.WriteLine("Finding password 2: 0/" + passwordLength);
            while (found < passwordLength)
            {
                string hash = Helper.MD5Hash(input + i, md5Hash);

                if (hash.Substring(0, 5) == "00000")
                {
                    try
                    {
                        int pos = int.Parse(hash[5] + "");

                        if (pos < password2.Length)
                            if (password2[pos] == '-')
                            {
                                password2[pos] = hash[6];

                                found++;
                                Console.WriteLine("Finding password 2: " + found + "/" + passwordLength);
                            }
                    }
                    catch { }
                }

                i++;
            }

            IO.Output(password1, false);
            IO.Output(new string(password2), true);


            Console.ReadKey();

        }


    }
}
