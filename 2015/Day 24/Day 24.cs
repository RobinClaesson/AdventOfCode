using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_24
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = IO.InputRows_Int;

            //Finds every possible group

            Console.WriteLine("Creating Groups");
            List<List<int>> everyGroup = new List<List<int>>();

            double lastDone = 0;
            for (int i = 1; i <= input.Count - 2; i++)
            {
                double done = ((double)(i) / (double)(input.Count - 2));
                done = Math.Round(done, 2) * 100;

                if (done != lastDone)
                {
                    lastDone = done;
                    Console.Clear();
                    Console.WriteLine("Creating Groups " + i + "/" + (input.Count - 2) + " " + done + "%");
                }

                everyGroup.AddRange(EveryGroup(input, i));
            }

            int lowestQE = int.MaxValue;

            //Checks every combination of group
            lastDone = 0;
            for (int g1 = 0; g1 < everyGroup.Count; g1++)
            {
                double done = ((double)(g1) / (double)(everyGroup.Count));
                done = Math.Round(done, 2) * 100;

                if (done != lastDone)
                {
                    lastDone = done;
                    Console.Clear();
                    Console.WriteLine("Calculating QE " + done + "%");
                }
                for (int g2 = 0; g2 < everyGroup.Count; g2++)
                {
                    //Check so that g1 and g2 arent the same and that g1 is smaller than g2
                    if (g1 != g2 && everyGroup[g1].Count <= everyGroup[g2].Count)
                        for (int g3 = 0; g3 < everyGroup.Count; g3++)
                        {
                            //Check so that g1 and g3 arent the same, and the same with g2 and g3
                            //Also checks if g1 is smaller than g2´3
                            if (g1 != g3 && g2 != g3 && everyGroup[g1].Count < everyGroup[g3].Count)
                            {
                                //Variables for eas of mind
                                List<int> group1 = everyGroup[g1];
                                List<int> group2 = everyGroup[g2];
                                List<int> group3 = everyGroup[g3];

                                //if we have the same nuber of packages as input
                                if (group1.Count + group2.Count + group3.Count == input.Count)
                                {
                                    //The same number cant be here twice
                                    bool copy = false;

                                    foreach (int number in group1)
                                    {
                                        if (group2.Contains(number))
                                            copy = true;

                                        if (group3.Contains(number))
                                            copy = true;
                                    }

                                    //Now we know if any of group1s number is in either group2 or group3
                                    if (!copy)
                                    {
                                        foreach (int number in group2)
                                        {
                                            if (group3.Contains(number))
                                                copy = true;
                                        }

                                        //Now we now if there are any matches between group 2 and 3
                                        if (!copy)
                                        {
                                            //Now we have 3 groups that are not the same and together is the length of the original list
                                            //where group1 is the smallest 

                                            if (group1.Sum() == group2.Sum() && group2.Sum() == group3.Sum())
                                            {
                                                //if they all have the same sum we can calculate the QE and see if its lower than the lowest known
                                                int qe = 1;

                                                foreach (int number in group1)
                                                    qe *= number;

                                                if (qe < lowestQE)
                                                    lowestQE = qe;
                                            }

                                        }
                                    }


                                }
                            }
                        }
                }
            }


            IO.Output(lowestQE);

            Console.ReadKey();

        }

        static List<List<int>> EveryGroup(List<int> list, int size)
        {
            //Creates every possible group with size number of items from list without doubles {1,2} is the same as {2,1}
            List<List<int>> groups = new List<List<int>>();

            for (int i = 0; i < list.Count(); i++)
            {
                int current = list[i];

                //the group is the wanted size we check if we have that list and adds it if we dont
                if (size == 1)
                {
                    groups.Add(new List<int>() { current });
                }

                //If we are not that size yet we get every group with (size-1) from the list without the current to build on the list
                else
                {
                    List<int> withoutCurrent = new List<int>();
                    withoutCurrent.AddRange(list);
                    withoutCurrent.RemoveAt(i);

                    List<List<int>> newGroups = EveryGroup(withoutCurrent, size - 1);

                    foreach (List<int> newGroup in newGroups)
                    {
                        newGroup.Insert(0, current);

                        bool hasNewGroup = false;

                        foreach (List<int> group in groups)
                        {
                            if (newGroup.Count == group.Count)
                            {
                                if (group.All(newGroup.Contains))
                                    hasNewGroup = true;
                            }

                        }

                        if (!hasNewGroup)
                            groups.Add(newGroup);
                    }


                }
            }

            return groups;
        }


    }
}
