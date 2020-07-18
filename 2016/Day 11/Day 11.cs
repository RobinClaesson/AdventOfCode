using AoC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> input = IO.InputRowsSplitted(',');

            List<List<Item>> floors = new List<List<Item>>();

            //Loads the floors from the input
            foreach (string[] row in input)
            {
                List<Item> floor = new List<Item>();

                foreach (string item in row)
                {
                    string[] words = item.Split(' ');

                    if (words.Last().Contains("generator"))
                    {
                        floor.Add(new Item(Type.Generator, words[words.Length - 2]));
                    }

                    else if (words.Last().Contains("micro"))
                    {
                        floor.Add(new Item(Type.Microchip, words[words.Length - 2].Split('-')[0]));
                    }
                }

                floors.Add(floor);
            }


            IO.Output(StepsToTopFloor(floors));
            Console.ReadKey();

        }

        static int StepsToTopFloor(List<List<Item>> floors, int currentFloor, int depth, List<List<List<Item>>> pastItirations)
        {
            //Primitive Loop stopper
            //if (depth > 20)
            //    return int.MaxValue;


            //Making a move
            List<int> depths = new List<int>();
            depth += int.MaxValue;

            List<int> nextCurrents = new List<int>();
            nextCurrents.Add(currentFloor + 1);

            //If all floors bellow us is empty there is no point of moving down
            if (HighestEmptyFloor(floors) < currentFloor - 1)
                nextCurrents.Add(currentFloor - 1);

            foreach (int nextCurrent in nextCurrents)
            {

                //We check if the floor exists and
                if (nextCurrent >= 0 && nextCurrent <= 3)
                {
                    //I can bring either 1 or 2 items, so I want to test both possibilities 
                    for (int numOfItems = 1; numOfItems <= 2; numOfItems++)
                    {
                        //We check if there is enough items on the floor
                        if (floors[nextCurrent].Count >= numOfItems)
                        {
                            //Every way we kan bring i items
                            List<List<Item>> itemCombos = Helper.EveryCombinationOfItems(floors[currentFloor], numOfItems, false);

                            //We want to test every possible combination of items we can bring
                            foreach (List<Item> itemsToBring in itemCombos)
                            {
                                //Copies so every variation of move doesn't effect each other
                                List<List<Item>> nextFloors = CopyFloors(floors);

                                //Removes the items we bring from the floor
                                foreach (Item item in itemsToBring)
                                {
                                    nextFloors[currentFloor] = RemoveItem(nextFloors[currentFloor], item);

                                }


                                //We move the items to their new floor
                                nextFloors[nextCurrent].AddRange(itemsToBring);


                                //We check if we have seen this itiration before
                                if (!HaveSeenBefore(pastItirations, nextFloors))
                                {
                                    pastItirations.Add(nextFloors);
                                    //We check if we are done

                                    //If we found no items on any of the other floors we are done and return depth+1
                                    //If this got us to the end there is no other move on this floor that could have done it
                                    //so there is no point to adding it to the list.
                                    if (HighestEmptyFloor(nextFloors) >= nextFloors.Count - 1)
                                    {
                                        Console.WriteLine("FOUND SOULTION WITH " + (depth + 1) + " steps");
                                        return depth + 1;
                                    }

                                    //We check if everything is ok
                                    bool broken = false;

                                    foreach (List<Item> floor in nextFloors)
                                    {
                                        foreach (Item item in floor)
                                        {
                                            if (item.Type == Type.Microchip)
                                            {
                                                bool hasOtherGenerator = false, hasSameGenerator = false;
                                                foreach (Item otherItem in floor)
                                                {
                                                    if (item.Type == Type.Generator)
                                                    {
                                                        if (item.Element == otherItem.Element)
                                                            hasSameGenerator = true;
                                                        else
                                                            hasOtherGenerator = true;
                                                    }
                                                }

                                                if (hasOtherGenerator && !hasSameGenerator)
                                                    broken = true;
                                            }

                                        }
                                    }

                                    //This means something broke and we dont want to explore this path further
                                    if (broken)
                                        depths.Add(int.MaxValue);



                                    //If its an okay state we iterate deeper
                                    else
                                    {
                                        depths.Add(StepsToTopFloor(CopyFloors(nextFloors), nextCurrent, depth + 1, pastItirations));
                                    }

                                }
                            }
                        }

                    }
                }


            }


            //We return the shortest found path
            return depths.Min();
        }

        static int StepsToTopFloor(List<List<Item>> floors)
        {
            return StepsToTopFloor(floors, 0, 0, new List<List<List<Item>>>() { floors});
        }




        static List<List<Item>> CopyFloors(List<List<Item>> floors)
        {
            List<List<Item>> copyFloors = new List<List<Item>>();

            foreach (List<Item> floor in floors)
            {
                List<Item> copyFloor = new List<Item>();

                foreach (Item item in floor)
                    copyFloor.Add(new Item(item));

                copyFloors.Add(copyFloor);
            }


            return copyFloors;
        }

        static List<Item> RemoveItem(List<Item> floor, Item item)
        {
            for (int i = 0; i < floor.Count; i++)
            {
                if (ItemIsSame(floor[i], item))
                {
                    floor.RemoveAt(i);
                    i--;
                }

            }

            return floor;
        }

        static bool ItemIsSame(Item item1, Item item2)
        {
            return (item1.Element == item2.Element && item1.Type == item2.Type);
        }

        static int HighestEmptyFloor(List<List<Item>> floors)
        {
            for (int i = 0; i < floors.Count; i++)
            {
                if (floors[i].Count > 0)
                    return i - 1;
            }

            return -1;
        }

        static bool HaveSeenBefore(List<List<List<Item>>> pastItirations, List<List<Item>> floors)
        {
            foreach (List<List<Item>> itiration in pastItirations)
            {
                if (AllFloorsAreSame(itiration, floors))
                    return true;
            }

            return false;
        }

        static bool FloorsAreSame(List<Item> floor1, List<Item> floor2)
        {
            if (floor1.Count != floor2.Count)
                return false;

            for (int i = 0; i < floor1.Count; i++)
                if (!ItemIsSame(floor1[i], floor2[i]))
                    return false;

            return true;
        }

        static bool AllFloorsAreSame(List<List<Item>> floors1, List<List<Item>> floors2)
        {
            foreach (List<Item> floor1 in floors1)
                foreach (List<Item> floor2 in floors2)
                    if (!FloorsAreSame(floor1, floor2))
                        return false;


            return true;
        }
    }
}
