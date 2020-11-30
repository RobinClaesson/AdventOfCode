using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = IO.Input;


            //Part 1
            for (int i = 0; i < 40; i++)
            {
                input = LookAndSay2(input);

            }

            
            IO.Output(input.Length);

            //Part 2

            for (int i = 40; i < 50; i++)
            {
                input = LookAndSay2(input);
            }
            IO.Output(input.Length, true);


            Console.ReadKey();
        }

        static string LookAndSay(string input)
        {
            string s = "";

            char prevLetter = input[0];
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == prevLetter)
                    count++;
                else
                {
                    s += count + prevLetter.ToString();
                    count = 1;
                    prevLetter = input[i];
                }
            }

            s += count + prevLetter.ToString();


            return s;
        }


        static string LookAndSay2(string number)
        {
            StringBuilder result = new StringBuilder();

            char repeat = number[0];
            number = number.Substring(1, number.Length - 1) + " ";
            int times = 1;

            foreach (char actual in number)
            {
                if (actual != repeat)
                {
                    result.Append(Convert.ToString(times) + repeat);
                    times = 1;
                    repeat = actual;
                }
                else
                {
                    times += 1;
                }
            }
            return result.ToString();
        }
    }
}
