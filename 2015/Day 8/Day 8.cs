using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> input = IO.InputRows;

            //Part 1
            int totalCode = 0, totalString = 0;

            foreach (string row in input)
            {
                totalCode += row.Length;
                int i = 1;
                while (i < row.Length - 1)
                {
                    if (row[i] == '\\')
                    {
                        if (row[i + 1] == 'x')
                        {
                            i += 4;
                        }

                        else
                        {
                            i += 2;
                        }


                    }

                    else
                    {

                        i++;
                    }

                    totalString++;
                }
            }


            IO.Output(totalCode - totalString);



            //Part 2
            Console.WriteLine("Part 2");

            int totalEncoded = 0;

            foreach (string row in input)
            {
                string code = "\"";

                foreach (char c in row)
                {
                    if (c == '\\')
                        code += "\\\\";
                    else if (c == '\"')
                        code += "\\\"";
                    else
                        code += c;
                }

                code += "\"";

                totalEncoded += code.Length;
            }

            IO.Output(totalEncoded - totalCode, true);
            Console.ReadKey();
        }

    }
}
