using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 137683, end = 596253;
            int counter = 0;

            for (int i = start; i <= end; i++)
            {
                char[] password = ("" + i).ToCharArray();
                bool rising = true, hasDouble = false;

                for (int j = 1; j < password.Length; j++)
                {
                    if (password[j] == password[j - 1])
                        hasDouble = true;

                    else if (password[j] < password[j - 1])
                        rising = false;
                }

                if (rising && hasDouble)
                    counter++;
            }

            Console.WriteLine("Part 1: " + counter);

            counter = 0;
            for (int i = start; i <= end; i++)
            {
                char[] password = ("" + i).ToCharArray();

                int j = 0;
                bool rising = true, hasDouble = false;
                while (j < password.Length)
                {
                    int k = 0;
                    while (j + k < password.Length)
                    {
                        if (password[j] == password[j + k])
                            k++;
                        else
                            break;
                    }


                    if (k == 2)
                        hasDouble = true;

                    if (j != 0)
                        if (password[j] < password[j - 1])
                            rising = false; 
                                

                    j += k;
                }

                if (rising && hasDouble)
                    counter++;
            }

            Console.WriteLine("Part 2: " + counter);
            Console.ReadKey();
        }
    }
}
