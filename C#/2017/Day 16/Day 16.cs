using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_16
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputSplitted(',');

            string programs = "";

            for (char c = 'a'; c <= 'p'; c++)
                programs += c;

            string dance1 = Dance(programs, input.ToArray(), 1);
            string dance2 = Dance(programs, input.ToArray(), 1000000000);

            IO.Output(dance1);
            IO.Output(dance2, true);
            Console.ReadKey();
        }


        //This old one could take around 100h to run part 2, does part 1 instanty
        static List<char> DanceOld(List<char> programs, List<string> moves, int rounds)
        {
            List<char> newOrder = new List<char>();
            newOrder.AddRange(programs);
            for (int round = 0; round < rounds; round++)
            {
                if (rounds > 1000000)
                    if (round % (rounds / 1000000) == 0)
                    {
                        Console.Clear();
                        Console.Write("Round {1}/{2} = {0}% Done", (double)round / (double)(rounds / 100), round, rounds);

                    }
                foreach (string move in moves)
                {
                    if (move[0] == 's')
                    {
                        int steps = int.Parse(move.Substring(1));

                        List<char> insert = newOrder.GetRange(newOrder.Count - steps, steps);
                        newOrder.RemoveRange(newOrder.Count - steps, steps);
                        newOrder.InsertRange(0, insert);
                    }

                    else if (move[0] == 'x')
                    {
                        string[] pos = move.Substring(1).Split('/');

                        int a = int.Parse(pos[0]);
                        int b = int.Parse(pos[1]);

                        char temp = newOrder[a];
                        newOrder[a] = newOrder[b];
                        newOrder[b] = temp;

                    }

                    else if (move[0] == 'p')
                    {
                        int a = newOrder.IndexOf(move[1]);
                        int b = newOrder.IndexOf(move[3]);

                        char temp = newOrder[a];
                        newOrder[a] = newOrder[b];
                        newOrder[b] = temp;
                    }
                }
            }

            return newOrder;
        }


        //This new one run both instantly
        static string Dance(string programs, string[] moves, int rounds)
        {
            List<string> seen = new List<string>();
            seen.Add(programs);



            for (int round = 0; round < rounds; round++)
            {

                for (int i = 0; i < moves.Length; i++)
                {

                    StringBuilder sb = new StringBuilder();
                    switch (moves[i][0])
                    {
                        case 's':
                            int steps = int.Parse(moves[i].Substring(1));

                            string move = programs.Substring(programs.Length - steps);
                            sb.Append(move);
                            sb.Append(programs.Substring(0, programs.Length - steps));
                            break;

                        case 'x':
                            string[] pos = moves[i].Substring(1).Split('/');

                            int xA = int.Parse(pos[0]);
                            int xB = int.Parse(pos[1]);

                            int xT = Math.Max(xA, xB);
                            xA = Math.Min(xA, xB);
                            xB = xT;

                            sb.Append(programs.Substring(0, xA));
                            sb.Append(programs[xB]);
                            sb.Append(programs.Substring(xA + 1, xB - xA - 1));
                            sb.Append(programs[xA]);
                            sb.Append(programs.Substring(xB + 1));
                            break;

                        case 'p':
                            int pA = programs.IndexOf(moves[i][1]);
                            int pB = programs.IndexOf(moves[i][3]);

                            int pT = Math.Max(pA, pB);
                            pA = Math.Min(pA, pB);
                            pB = pT;

                            sb.Append(programs.Substring(0, pA));
                            sb.Append(programs[pB]);
                            sb.Append(programs.Substring(pA + 1, pB - pA - 1));
                            sb.Append(programs[pA]);
                            sb.Append(programs.Substring(pB + 1));
                            break;
                    }
                    programs = sb.ToString();
                }

                if (!seen.Contains(programs))
                {
                    seen.Add(programs);
                }

                else
                {
                    int jump = seen.Count - seen.IndexOf(programs);

                    while (round + jump < rounds)
                        round += jump;
                }
            }

            return programs;
        }

    }
}
