using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {

            string password = IO.Input;

            //Part 1

            password = NextPassword(password);
            IO.Output(password);

            Console.WriteLine("Part 2");

            password = NextPassword(password);
            IO.Output(password, true);

            Console.ReadKey();
        }

        static string NextPassword(string currentPassword)
        {
            char[] password = currentPassword.ToCharArray();

            bool approved = false;

            while (!approved)
            {
                password[password.Length - 1]++;

                for (int i = password.Length - 1; i >= 0; i--)
                {
                    if (password[i] > 'z')
                    {
                        password[i - 1]++;
                        password[i] = 'a';
                    }


                }

                bool hasRising = false;
                for (int i = 0; i < password.Length - 2; i++)
                    if ((password[i] + 1) == password[i + 1] && (password[i] + 2) == password[i + 2])
                        hasRising = true;

                bool hasUnallowedLetter = false;
                for (int i = 0; i < password.Length; i++)
                    if (password[i] == 'i' || password[i] == 'o' || password[i] == 'l')
                        hasUnallowedLetter = true;

                int overlapping = 0;
                for (int i = 0; i < password.Length-1; i++)                
                   if(password[i] == password[i+1])
                    {
                        overlapping++;
                        i++;
                    }
                

                if (hasRising && !hasUnallowedLetter && overlapping >= 2)
                    approved = true;
            }

            string s = "";
            foreach (char c in password)
                s += c;

            return s;
        }
    }
}
