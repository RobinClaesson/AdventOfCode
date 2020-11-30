using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<string> input = IO.InputRows;
            List<Wire> wires = new List<Wire>();

            //Part 1
            for (int i = 0; i < input.Count; i++)
            {
                string id = input[i].Split(' ')[input[i].Split(' ').Length - 1];
                wires.Add(new Wire(input[i].Split(' ')[input[i].Split(' ').Length - 1]));
            }


            string targetWire = "a";
            int indexOfTarget = WireIndex(wires, targetWire);


            DoInstructions(input, wires, indexOfTarget);
            IO.Output(wires[indexOfTarget].signal);


            //Part 2
            input = IO.InputRows;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Split(' ')[input[i].Split(' ').Length - 1] == "b")
                    input[i] = wires[indexOfTarget].signal + " -> b";
            }

            foreach (Wire wire in wires)
                wire.signal = int.MinValue;

            DoInstructions(input, wires, indexOfTarget);
            IO.Output(wires[indexOfTarget].signal, true);

            Console.ReadKey();
        }

        private static void DoInstructions(List<string> input, List<Wire> wires, int indexOfTarget)
        {
            while (wires[indexOfTarget].signal == int.MinValue)
            {
                List<int> doneRows = new List<int>();

                for (int row = 0; row < input.Count; row++)
                {
                    if (input[row].Contains("AND"))
                    {
                        string id1 = input[row].Split(' ')[0];
                        string id2 = input[row].Split(' ')[2];

                        int signal1;

                        if (WireIndex(wires, id1) == -1)
                            signal1 = int.Parse(id1);
                        else
                            signal1 = wires[WireIndex(wires, id1)].signal;

                        int signal2 = wires[WireIndex(wires, id2)].signal;

                        if (signal1 != int.MinValue && signal2 != int.MinValue)
                        {
                            string idTarget = input[row].Split(' ')[4];

                            wires[WireIndex(wires, idTarget)].signal = signal1 & signal2;
                            doneRows.Add(row);
                        }
                    }

                    else if (input[row].Contains("OR"))
                    {
                        string id1 = input[row].Split(' ')[0];
                        string id2 = input[row].Split(' ')[2];

                        int signal1 = wires[WireIndex(wires, id1)].signal;
                        int signal2 = wires[WireIndex(wires, id2)].signal;

                        if (signal1 != int.MinValue && signal2 != int.MinValue)
                        {
                            string idTarget = input[row].Split(' ')[4];

                            wires[WireIndex(wires, idTarget)].signal = signal1 | signal2;
                            doneRows.Add(row);
                        }
                    }

                    else if (input[row].Contains("LSHIFT"))
                    {
                        string id = input[row].Split(' ')[0];


                        int signal = wires[WireIndex(wires, id)].signal;

                        if (signal != int.MinValue)
                        {
                            int bits = int.Parse(input[row].Split(' ')[2]);
                            string idTarget = input[row].Split(' ')[4];

                            wires[WireIndex(wires, idTarget)].signal = signal << bits;
                            doneRows.Add(row);
                        }
                    }

                    else if (input[row].Contains("RSHIFT"))
                    {
                        string id = input[row].Split(' ')[0];


                        int signal = wires[WireIndex(wires, id)].signal;

                        if (signal != int.MinValue)
                        {
                            int bits = int.Parse(input[row].Split(' ')[2]);
                            string idTarget = input[row].Split(' ')[4];

                            wires[WireIndex(wires, idTarget)].signal = signal >> bits;
                            doneRows.Add(row);
                        }
                    }

                    else if (input[row].Contains("NOT"))
                    {
                        string id = input[row].Split(' ')[1];


                        int signal = wires[WireIndex(wires, id)].signal;

                        if (signal != int.MinValue)
                        {
                            string bits = Convert.ToString(signal, 2);

                            while (bits.Length < 16)
                                bits = "0" + bits;

                            int bitsNOT = 0;
                            for (int j = 0; j < bits.Length; j++)
                            {
                                if (bits[j] == '0')
                                    bitsNOT += (int)Math.Pow(2, (bits.Length - j - 1));

                            }

                            string idTarget = input[row].Split(' ')[3];
                            wires[WireIndex(wires, idTarget)].signal = bitsNOT;
                            doneRows.Add(row);

                        }
                    }

                    else
                    {
                        string id = input[row].Split(' ')[0];
                        int signal = int.MinValue;

                        if (WireIndex(wires, id) != -1)
                            signal = wires[WireIndex(wires, id)].signal;
                        else
                            signal = int.Parse(id);

                        if (signal != int.MinValue)
                        {
                            string idTarget = input[row].Split(' ')[2];

                            wires[WireIndex(wires, idTarget)].signal = signal;
                            doneRows.Add(row);
                        }
                    }
                }

                for (int i = 0; i < doneRows.Count; i++)
                    input.RemoveAt(doneRows[i] - i);

            }
        }

        static int WireIndex(List<Wire> wires, string wireId)
        {
            for (int i = 0; i < wires.Count; i++)
                if (wires[i].id == wireId)
                    return i;

            return -1;
        }
    }
}
