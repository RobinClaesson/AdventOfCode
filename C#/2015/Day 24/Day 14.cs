using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Day_24
{
    class Program
    {
        static void Main(string[] args)
        {
            //Realisations
            //I don't have to know the other groups, its enough that i know what is not in the first group
            //I know that there is a way to balance the sleigh if the weigh if the rest is (numberOfGroups-1)*(weigth of first)
            //From there i can easily find the smallest balanced groups and calculate smallest QE
            //Its also enugh to only check groups that have length upto (1/numberOfGroups) because any larger than that wont be the shortest even it it can balance
            List<int> input = IO.InputRows_Int;

            IO.Output(SmallestQE(input, 3));
            IO.Output(SmallestQE(input, 4), true);
            Console.ReadKey();
        }


        private static long SmallestQE(List<int> input, int numberOfGroups)
        {
            //Gets every possible group with length up to 1/(groups) of the total number of packages
            //Groups longer than cant sit in front
            Console.WriteLine("----Finiding smallest QE for " + numberOfGroups + " groups----");
            Console.WriteLine("Creating groups");
            List<List<int>> groups = new List<List<int>>();
            for (int i = 1; i <= input.Count / numberOfGroups; i++)
            {
                groups.AddRange(GetGrups(input, 0, i));
            }



            //Finds the smallest balanced groups
            Console.WriteLine("Finds the smallest balanced groups");
            List<List<int>> smallestBalanced = new List<List<int>>();
            foreach (List<int> group in groups)
            {
                if (smallestBalanced.Count == 0)
                {
                    if (IsBalanced(group, input, numberOfGroups))
                    {
                        //This is the first balanced group we found so we add it
                        smallestBalanced.Add(group);
                    }
                }

                //We dont need to know if a group is balanced if its larger than the smallest we found
                else if (group.Count() <= smallestBalanced[0].Count)
                {
                    if (IsBalanced(group, input, numberOfGroups))
                    {
                        //We check if its the same size as the known
                        if (smallestBalanced[0].Count == group.Count)
                            smallestBalanced.Add(group);

                        //if its not the same we know its smaller
                        else
                        {
                            smallestBalanced.Clear();
                            smallestBalanced.Add(group);
                        }
                    }
                }

            }

            Console.WriteLine("Finds the smallest QE");

            long smallestQE = long.MaxValue;

            foreach (List<int> group in smallestBalanced)
            {
                long qe = 1;

                foreach (int i in group)
                    qe *= i;

                if (qe < smallestQE)
                    smallestQE = qe;
            }

            return smallestQE;
        }

        private static List<List<int>> GetGrups(List<int> source, int loopStart, int size)
        {
            List<List<int>> groups = new List<List<int>>();


            for (int i = loopStart; i < source.Count; i++)
            {
                int current = source[i];

                if (size <= 1)
                    groups.Add(new List<int>() { current });

                else
                {
                    List<int> withoutCurrent = new List<int>();
                    withoutCurrent.AddRange(source);
                    withoutCurrent.RemoveAt(i);

                    List<List<int>> subGroups = GetGrups(withoutCurrent, i, size - 1);

                    foreach (List<int> sub in subGroups)
                    {
                        //List<int> subToAdd = new List<int>();


                        //if(!ListContainsList(groups, sub))
                        //{
                        //    subToAdd.AddRange(sub);
                        //    groups.Add(subToAdd);
                        //}

                        sub.Insert(0, current);
                        groups.Add(sub);
                    }
                }
            }



            return groups;
        }

        private static bool IsBalanced(List<int> group, List<int> source, int numberOfGroups)
        {
            List<int> others = new List<int>();
            others.AddRange(source);

            foreach (int i in group)
                others.Remove(i);

            return ((numberOfGroups - 1) * group.Sum()) == others.Sum();
        }

    }
}
