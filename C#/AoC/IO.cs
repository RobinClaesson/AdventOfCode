using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection.Emit;
using System.IO.Pipes;

namespace AoC
{
    public class IO
    {
        //Straight input
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

        public static int Input_Int
        {
            get
            {
                return int.Parse(Input);
            }
        }

        //Input by row of text
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


        //Input by separation at separator
        public static List<string> InputSplitted(char separator)
        {
            return Input.Split(separator).ToList<string>();
        }

        public static List<int> InputSplitted_Int(char separator)
        {
            List<string> input = InputSplitted(separator);
            List<int> inputInt = new List<int>();

            for (int i = 0; i < input.Count; i++)
                inputInt.Add(int.Parse(input[i]));

            return inputInt;
        }

        public static List<long> InputSplitted_Long(char separator)
        {
            List<string> input = InputSplitted(separator);
            List<long> inputlong = new List<long>();

            for (int i = 0; i < input.Count; i++)
                inputlong.Add(long.Parse(input[i]));

            return inputlong;
        }


        //Input by row and separation at row
        public static List<string[]> InputRowsSplitted(char separator)
        {
            List<string> rows = InputRows;

            List<string[]> input = new List<string[]>();

            foreach (string row in rows)
            {
                input.Add(row.Split(separator));
            }

            return input;
        }

        public static List<int[]> InputRowsSplitted_Int(char separator)
        {
            List<string> rows = InputRows;

            List<int[]> input = new List<int[]>();

            foreach (string row in rows)
            {
                string[] splittedRow = row.Split(separator);

                List<int> toAdd = new List<int>();

                foreach (string part in splittedRow)
                    if(part != "")
                    toAdd.Add(int.Parse(part));

                input.Add(toAdd.ToArray());
            }

            return input;
        }


        //Answer outputs in console and to file
        private static int outputs = 0;
        private static void ClearOutput()
        {
            string path = "Output.txt";
            StreamWriter writer = new StreamWriter(path, false);
            writer.Write("");
            writer.Close();
        }

        public static void OpenOutput()
        {
            Process.Start("notepad.exe", "Output.txt");
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

            if (outputs == 2)
                Console.ReadKey();
        }
        public static void Output(string answer)
        {
            Output(answer, false);
        }

        public static void Output(long answer, bool openFile)
        {
            Output("" + answer, openFile);
        }

        public static void Output(long answer)
        {
            Output("" + answer, false);
        }

        public static void Output(float answer, bool openFile)
        {
            Output("" + answer, openFile);
        }

        public static void Output(float answer)
        {
            Output("" + answer, false);
        }

        public static void Output(int answer, bool openFile)
        {
            Output("" + answer, openFile);
        }
        public static void Output(int answer)
        {
            Output("" + answer, false);
        }

        



        //Logging for debuging etc

        static string logBuffer = "";
        public static void ClearLogFile()
        {
            StreamWriter writer = new StreamWriter("Log.txt", false);
            writer.Write("");
            writer.Close();
        }

        public static void WriteLogToFile(bool append, bool openFile)
        {
            StreamWriter writer = new StreamWriter("Log.txt", append);
            writer.WriteLine(logBuffer);
            writer.Close();

            logBuffer = "";

            if (openFile)
                OpenLogFile();
        }

        public static void WriteLogToFile()
        {
            WriteLogToFile(true, false);
        }

        public static void OpenLogFile()
        {
            Process.Start("notepad.exe", "Log.txt");
        }



        public static void Log(string log)
        {
            if ((logBuffer.Length + log.Length) >= 1073741791)//Max length of a string
            {
                WriteLogToFile(false, false);
            }

            logBuffer += log + "\r\n";
            
        }

        public static void Log(int log)
        {
            Log("" + log);
        }

        public static void LogDivider()
        {
            Log("---------------------------------------------------------");
        }



    }
}
