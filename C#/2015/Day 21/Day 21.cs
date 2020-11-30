using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = IO.InputRows.ToArray();
            Unit bossMax = new Unit(int.Parse(input[0].Split(' ').Last()), int.Parse(input[1].Split(' ').Last()), int.Parse(input[2].Split(' ').Last()), null);

            //Sets up the store
            List<Item> weaponStore = new List<Item>();
            weaponStore.Add(new Item(8, 4, 0));
            weaponStore.Add(new Item(10, 5, 0));
            weaponStore.Add(new Item(25, 6, 0));
            weaponStore.Add(new Item(40, 7, 0));
            weaponStore.Add(new Item(74, 8, 0));

            List<Item> armorStore = new List<Item>();
            armorStore.Add(new Item(0, 0, 0)); //You can fight without armor and this free item simulate that
            armorStore.Add(new Item(13, 0, 1));
            armorStore.Add(new Item(31, 0, 2));
            armorStore.Add(new Item(53, 0, 3));
            armorStore.Add(new Item(75, 0, 4));
            armorStore.Add(new Item(102, 0, 5));

            List<Item> ringStore = new List<Item>();
            ringStore.Add(new Item(0, 0, 0));
            ringStore.Add(new Item(0, 0, 0)); //You can have 0-2 rings, these 2 empty items simulate that 
            ringStore.Add(new Item(25, 1, 0));
            ringStore.Add(new Item(50, 2, 0));
            ringStore.Add(new Item(100, 3, 0));
            ringStore.Add(new Item(20, 0, 1));
            ringStore.Add(new Item(40, 0, 2));
            ringStore.Add(new Item(80, 0, 3));




            int lowestWinCost = int.MaxValue;
            int highestLooseCost = int.MinValue;

            //This nest of loops goes through every cobination of weapon, armor and rings and finds the cheapest win
            foreach (Item weapon in weaponStore)
            {
                foreach (Item armor in armorStore)
                {
                    //Switching to for loops so we dont have the same ring at the same time
                    for (int i = 0; i < ringStore.Count; i++)
                    {
                        for (int j = 0; j < ringStore.Count; j++)
                        {
                            if (i != j)
                            {
                                Unit player = new Unit(100, 0, 0, new Item[] { weapon, armor, ringStore[i], ringStore[j] }.ToList());

                                if (player.totalCost < lowestWinCost)
                                {
                                    Unit boss = new Unit(bossMax);
                                    if (WinBattle(player, boss))
                                        lowestWinCost = player.totalCost;
                                }

                                if (player.totalCost > highestLooseCost)
                                {
                                    Unit boss = new Unit(bossMax);
                                    if (!WinBattle(player, boss))
                                        highestLooseCost = player.totalCost;

                                }
                            }
                        }

                    }
                }
            }


            IO.Output(lowestWinCost);
            IO.Output(highestLooseCost);

            //Part 2

            Console.ReadKey();
        }

        public static bool WinBattle(Unit player, Unit boss)
        {

            while (true)
            {
                boss.TakeDamage(player.damage);
                if (boss.hp == 0)
                    return true;

                player.TakeDamage(boss.damage);
                if (player.hp == 0)
                    return false;
            }
        }
    }
}
