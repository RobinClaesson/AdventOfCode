using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day3
{
    class Day3
    {
        static void Main(string[] args)
        {
            List<char[]> input = IO.InputRowsArray;

            //Part 1
            string least = "", most = "";
            for (int x = 0; x < input[0].Length; x++)
            {
                int ones = 0, zeroes = 0;
                for (int y = 0; y < input.Count; y++)
                {
                    if (input[y][x] == '0')
                        zeroes++;
                    else
                        ones++;
                }

                if (zeroes < ones)
                {
                    least += "0";
                    most += "1";
                }
                else
                {
                    least += "1";
                    most += "0";
                }
            }

            int gamma = Convert.ToInt32(most, 2);
            int epsilon = Convert.ToInt32(least, 2);
            IO.Output(gamma * epsilon);



            //Part 2
            List<char[]> oxygen = new List<char[]>();
            oxygen.AddRange(input);
            for (int x = 0; x < oxygen[0].Length; x++)
            {
                int ones = 0, zeroes = 0;
                for (int y = 0; y < oxygen.Count; y++)
                {
                    if (oxygen[y][x] == '0')
                        zeroes++;
                    else
                        ones++;
                }
                if (ones >= zeroes)
                {
                    for (int i = 0; i < oxygen.Count; i++)
                        if (oxygen[i][x] == '0')
                            oxygen.RemoveAt(i--);
                }

                else
                {
                    for (int i = 0; i < oxygen.Count; i++)
                        if (oxygen[i][x] == '1')
                            oxygen.RemoveAt(i--);
                }

                if (oxygen.Count == 1)
                    break;
            }


            List<char[]> co2 = new List<char[]>();
            co2.AddRange(input);
            for (int x = 0; x < co2[0].Length; x++)
            {
                int ones = 0, zeroes = 0;
                for (int y = 0; y < co2.Count; y++)
                {
                    if (co2[y][x] == '0')
                        zeroes++;
                    else
                        ones++;
                }

                if (ones >= zeroes)
                {
                    for (int i = 0; i < co2.Count; i++)
                        if (co2[i][x] == '1')
                            co2.RemoveAt(i--);
                }

                else
                {
                    for (int i = 0; i < co2.Count; i++)
                        if (co2[i][x] == '0')
                            co2.RemoveAt(i--);
                }

                if (co2.Count == 1)
                    break;
            }

            IO.Output(Convert.ToInt32(new string(oxygen[0]), 2) * Convert.ToInt32(new string(co2[0]), 2));
            Console.ReadKey();
        }
    }
}
