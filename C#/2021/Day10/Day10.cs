using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Day10
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;


            int part1Score = 0;
            List<long> part2Scores = new List<long>();
            foreach (string row in input)
            {
                Stack<char> openingBrackets = new Stack<char>();
                bool corrupted = false;

                //Part 1
                for (int i = 0; i < row.Length; i++)
                {
                    char current = row[i];

                    //Opening bracket
                    if (current == '(' || current == '{' || current == '[' || current == '<')
                    {
                        openingBrackets.Push(current);
                    }
                    //Closing bracket
                    else
                    {
                        char lastOpen = openingBrackets.Pop();

                        //Different types of brackets
                        if (Math.Abs(current - lastOpen) > 5)
                        {
                            switch (current)
                            {
                                case ')':
                                    part1Score += 3;
                                    break;

                                case ']':
                                    part1Score += 57;
                                    break;

                                case '}':
                                    part1Score += 1197;
                                    break;

                                case '>':
                                    part1Score += 25137;
                                    break;
                            }

                            corrupted = true;
                            break;
                        }
                    }

                }

                //Part 2
                if (!corrupted)
                {
                    long score = 0;
                    while (openingBrackets.Count > 0)
                    {
                        char c = openingBrackets.Pop();

                        score *= 5;

                        switch(c)
                        {
                            case '(':
                                score += 1;
                                break;

                            case '[':
                                score += 2;
                                break;

                            case '{':
                                score += 3;
                                break;

                            case '<':
                                score += 4;
                                break;
                        }
                    }

                    part2Scores.Add(score);
                }
            }
            IO.Output(part1Score);

            part2Scores.Sort();
            IO.Output(part2Scores[part2Scores.Count / 2]);
            
            
            Console.ReadKey();
        }
    }
}
