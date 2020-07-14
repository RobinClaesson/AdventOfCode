using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
    class Program
    {
        static int lowestKnown;
        static void Main(string[] args)
        {
            IO.ClearLogFile();

            //List of all Spells
            List<Spell> spells = new List<Spell>();
            spells.Add(new Poison());
            spells.Add(new MagicMissile());
            spells.Add(new Recharge());
            spells.Add(new Shield());
            spells.Add(new Drain());

            List<string[]> input = IO.InputRowsSplitted(' ');

            //Part 1
            Boss boss1 = new Boss(int.Parse(input[0].Last()), int.Parse(input[1].Last()));
            Player player1 = new Player(0);

            lowestKnown = int.MaxValue;

            List<int> part1Wins = ManaSpentToWin(player1, boss1, spells, "", false);
            IO.Output(part1Wins.Min());

            //Part 2
            Boss boss2 = new Boss(int.Parse(input[0].Last()), int.Parse(input[1].Last()));
            Player player2 = new Player(1);

            lowestKnown = int.MaxValue;

            List<int> part2Wins = ManaSpentToWin(player2, boss2, spells, "", false);
            IO.Output(part2Wins.Min());

            
            Console.ReadKey();

        }

        
        public static List<int> ManaSpentToWin(Player player, Boss boss, List<Spell> spells, string log, bool doLog)
        {

            List<int> manaSpent = new List<int>();

            //There is no need to go further if we know we can win with less mana than we now have used
            if (player.ManaSpent < lowestKnown)
            {

                //Copy player and boss variables to dont interfere with parent-path
                Player preSpellPlayer = new Player(player);
                Boss preSpellBoss = new Boss(boss);

                string preSpellLog = "";

                //------- PLAYERS TURN -------

                if (doLog)
                    preSpellLog += "-- Player turn --\r\n-Player has " + preSpellPlayer.HP + " HP, " + preSpellPlayer.Mana + " Mana\r\n-Boss has " + preSpellBoss.HP + " HP\r\n";
                //Before anything check if the player dies from the round HP loss
                //If the player dies we return an empty list, because there is now wins down this path
                if (!preSpellPlayer.DiesFromRoundHpLost())
                {
                    if (preSpellBoss.IsPoisoned && doLog)
                    {

                        preSpellLog += "-Boss takes " + new Poison().Value + " dmg from poison. Boss has " + (preSpellBoss.HP - new Poison().Value) + " HP\r\n";
                    }
                    //Check if the boss dies from poison
                    if (preSpellBoss.DiesFromPoison())
                    {
                        //If the boss dies we add the total mana spent so far to the list and dont check for anything else
                        manaSpent.Add(preSpellPlayer.ManaSpent);

                        //Checks to see if the is the best one yet
                        if (preSpellPlayer.ManaSpent < lowestKnown)
                            lowestKnown = preSpellPlayer.ManaSpent;

                        if (doLog)
                        {
                            IO.Log(log + preSpellLog + " - Boss died to poison");
                            IO.Log("Mana Spent: " + preSpellPlayer.ManaSpent);
                            IO.Log("------------------------------");
                        }

                    }

                    //If the boss survives the poison
                    else
                    {
                        //Update the players timers
                        preSpellPlayer.UpdateTimers();


                        //Goes through each spell and forks a "path" where that spell is used if the boss survives it
                        foreach (Spell spell in spells)
                        {
                            string spellLog = "";
                            //Checks if the player can cast the spell
                            if (preSpellPlayer.CanCastSpell(spell))
                            {
                                //Copy player and boss variables to dont interfere with sibling-paths
                                Player spellPlayer = new Player(preSpellPlayer);
                                Boss spellBoss = new Boss(preSpellBoss);

                                //Player casts spells, looses mana and applies effects to self
                                spellPlayer.CastSpell(spell);

                                if (doLog)
                                    spellLog += "-Player cast \"" + spell.Name + "\"\r\n";

                                //Checks if the boss dies from the spell
                                if (spellBoss.DiesFromSpell(spell))
                                {
                                    //If the boss dies we add the total mana spent after the used spell
                                    manaSpent.Add(spellPlayer.ManaSpent);

                                    if (spellPlayer.ManaSpent < lowestKnown)
                                        lowestKnown = spellPlayer.ManaSpent;

                                    if (doLog)
                                    {
                                        IO.Log(log + preSpellLog + spellLog + "-Boss died to " + "\"" + spell.Name + "\"");
                                        IO.Log("Mana Spent: " + spellPlayer.ManaSpent);
                                        IO.Log("------------------------------");
                                    }
                                }

                                else
                                {
                                    //If the boss survives the spell he gets his turn

                                    //------ BOSS TURN ------
                                    if (doLog)
                                        spellLog += "\r\n-- Boss turn --\r\n-Player has " + spellPlayer.HP + " HP, " + spellPlayer.Mana + " Mana\r\n-Boss has " + spellBoss.HP + " HP\r\n";
                                    //Checks if boss dies from poison


                                    if (spellBoss.IsPoisoned && doLog)
                                    {

                                        spellLog += "-Boss takes " + new Poison().Value + " dmg from poison. Boss has " + (spellBoss.HP - new Poison().Value) + " HP\r\n";
                                    }

                                    if (spellBoss.DiesFromPoison())
                                    {
                                        //If the boss dies we add the total mana spent so far
                                        manaSpent.Add(spellPlayer.ManaSpent);

                                        if (spellPlayer.ManaSpent < lowestKnown)
                                            lowestKnown = spellPlayer.ManaSpent;

                                        if (doLog)
                                        {
                                            IO.Log(log + preSpellLog + spellLog + "-Boss died to poison");
                                            IO.Log("Mana Spent: " + spellPlayer.ManaSpent);
                                            IO.Log("------------------------------");
                                        }
                                            
                                    }

                                    else
                                    {
                                        //The boss survives the poison

                                        //Update player timers
                                        spellPlayer.UpdateTimers();
                                        if (doLog)
                                            spellLog += "-Boss attacks player for " + spellBoss.AttackDamage + "\r\n";
                                        //checks if the player survives from the boss attack
                                        if (!spellPlayer.DiesFromAttack(spellBoss.AttackDamage))
                                        {
                                            //If the player have survived the boss attack it's the player turn again so we add the results of all the forks with this spell
                                            //and when we return we return to the loop to check what happends if we use the other spells
                                            manaSpent.AddRange(ManaSpentToWin(spellPlayer, spellBoss, spells, log + preSpellLog + spellLog + "\r\n", doLog));
                                        }

                                        else
                                        {

                                            //IO.Log(log + preSpellLog + spellLog + "-Player dies to boss");
                                            //IO.Log("------------------------------");
                                        }


                                    }
                                }
                            }
                        }

                    }

                }

                else
                {
                    //Console.WriteLine(log + preSpellLog + "-Player died from pre-round HP-lost");
                    //Console.ReadKey();
                    //Console.Clear();

                    //IO.Log(log + preSpellLog + "-Player died from pre-round HP-lost");
                    //IO.Log("------------------------------");
                }
            }

            return manaSpent;
        }
    }
}
