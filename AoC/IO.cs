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
        public static List<int> InputRows_Int
        {
            get
            {
                List<string> stringList = InputRows;

                List<int> intList = new List<int>();

                foreach (string s in stringList)
                    intList.Add(int.Parse(s));

                return intList;
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



        private static int outputs = 0;
        private static void ClearOutput()
        {
            string path = "Output.txt";
            StreamWriter writer = new StreamWriter(path, false);
            writer.Write("");
            writer.Close();
        }
        public static void Output(string answer, bool openFile)
        {
            if (outputs == 0)
                ClearOutput();
            outputs++;

            string path = "Output.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("Part " + outputs + ": " + answer);
            writer.Close();
            Console.WriteLine("Answer part " + outputs + ": " + answer);

            if (openFile)
                Process.Start("notepad.exe", path);
        }
        public static void Output(string answer)
        {
            Output(answer,  false);
        }

        public static void Output(int answer,  bool openFile)
        {
            Output("" + answer,  openFile);
        }
        public static void Output(int answer)
        {
            Output("" + answer, false);
        }
    }
}
