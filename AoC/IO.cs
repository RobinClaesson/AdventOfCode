using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection.Emit;

namespace AoC
{
    public class IO
    {
        public static string Input
        {
            get
            {
                string s = "";

                if (File.Exists("Input.txt"))
                {
                    StreamReader reader = new StreamReader("Input.txt");
                    s = reader.ReadToEnd();
                    reader.Close();
                }

                return s;
            }
        }

        public static List<string> InputRows
        {
            get
            {
                List<string> input = new List<string>();

                if (File.Exists("Input.txt"))
                {
                    StreamReader reader = new StreamReader("Input.txt");

                    string read;

                    while ((read = reader.ReadLine()) != null)
                        input.Add(read);

                    reader.Close();
                }

                return input;
            }
        }

        public static List<string> SplittedInput(char separator)
        {
            return Input.Split(separator).ToList<string>();
        }

        public static List<int> SplittedInputInt(char separator)
        {
            List<string> input = SplittedInput(separator);
            List<int> inputInt = new List<int>();

            for (int i = 0; i < input.Count; i++)
                inputInt.Add(int.Parse(input[i]));

            return inputInt;
        }





        public static void Output(string answer, int part, bool openFile)
        {
            string path = "Output.txt";
            StreamWriter writer = new StreamWriter(path, false);
            writer.Write(answer);
            writer.Close();
            Console.WriteLine("Answer part " + part + ": " + answer);

            if (openFile)
                Process.Start("notepad.exe", path);
        }
        public static void Output(string answer, int part)
        {
            Output(answer, part, false);
        }

        public static void Output(int answer, int part, bool openFile)
        {
            Output("" + answer, part, openFile);
        }
        public static void Output(int answer, int part)
        {
            Output("" + answer, part, false);
        }
    }
}
