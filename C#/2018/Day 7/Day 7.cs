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
            List<string[]> input = IO.InputRowsSplitted(' ');

            input = input.OrderBy(s => s[7]).ToList(); //Sort by second letter


            //Finds the prerequisite
            List<string> toPlace = new List<string>();
            int i = 0;
            while (i < input.Count)
            {
                string s = input[i][7];
                string before = "";

                while (i < input.Count && input[i][7] == s)
                {
                    before += input[i][1];

                    i++;
                }

                s += before;
                toPlace.Add(s);
            }

            string output = "";

            //Finds the letters without prerequisite
            foreach (string[] row in input)
            {
                bool without = true;

                foreach (string s in toPlace)
                {
                    if (row[1][0] == s[0])
                    {
                        without = false;
                        break;
                    }
                }

                if (without)
                {
                    toPlace.Add(row[1]);
                }
            }

            toPlace = toPlace.OrderBy(s => s.Length).ThenBy(s => s[0]).ToList();

            List<string> toPlaceDupe = new List<string>();
            toPlaceDupe.AddRange(toPlace);

            while (toPlace.Count > 0)
            {
                for (i = 0; i < toPlace.Count; i++)
                {
                    //Finds the first letter that we can place
                    if (toPlace[i].Length == 1)
                    {
                        output += toPlace[i];
                        //Console.WriteLine(output);

                        //Removes every occurrence of this letter
                        for (int j = 0; j < toPlace.Count; j++)
                        {
                            if (i != j && toPlace[j].IndexOf(toPlace[i]) != -1)
                            {
                                toPlace[j] = toPlace[j].Remove(toPlace[j].IndexOf(toPlace[i]), 1);
                            }
                        }

                        //Removes the placed letter than resorts the list and starts the search from the begining
                        toPlace.RemoveAt(i);
                        toPlace = toPlace.OrderBy(s => s.Length).ThenBy(s => s[0]).ToList();
                        i = -1; //Gets set to 0 straight after by the loop
                    }
                }
            }

            IO.Output(output);

            //Part 2
            output = "";
            toPlace = toPlaceDupe;

            int seconds = 0;
            Worker[] workers = new Worker[] { new Worker(60), new Worker(60), new Worker(60), new Worker(60), new Worker(60) };

            int target = toPlace.Count;
            //IO.ClearLogFile();
            //IO.Log("Second\tWorker 1\tWorker 2\tDone");

            while (output.Length != target)
            {
                //Completes each worker
                foreach (Worker worker in workers)
                {
                    if (worker.IsDone)
                    {
                        //Removes the done letter from the prerequisites
                        if (worker.WorkingOn != ".")
                        {
                            output += worker.WorkingOn;
                            for (i = 0; i < toPlace.Count; i++)
                            {

                                if (toPlace[i].IndexOf(worker.WorkingOn) != -1)
                                {
                                    toPlace[i] = toPlace[i].Remove(toPlace[i].IndexOf(worker.WorkingOn), 1);
                                }

                            }
                            worker.Reset();
                        }
                    }


                }

                //Finds new work and works it
                //This must be done in a separate loop, otherwise wrong worker can pick up some tasks
                foreach (Worker worker in workers)
                {
                    if (worker.IsDone)
                    {
                        //Finds next to work on 
                        toPlace = toPlace.OrderBy(s => s.Length).ThenBy(s => s[0]).ToList();

                        if (toPlace.Count > 0 && toPlace[0].Length == 1)
                        {
                            worker.StartWork(toPlace[0]);
                            toPlace.RemoveAt(0);
                        }
                    }

                    worker.Work();
                }

                //Console.WriteLine("Second: " + seconds + "\t| Worker 1: " + workers[0].WorkingOn + "\t| Worker 2: " + workers[1].WorkingOn);
                string log = seconds + "\t";
                foreach (Worker worker in workers)
                {
                    log += worker.WorkingOn + "\t";
                }
                log += output;
                IO.Log(log);
                //IO.Log(seconds + "\t" + workers[0].WorkingOn + "\t" + workers[1].WorkingOn + "\t" + output);
                seconds++;
            }

            seconds--;
            IO.WriteLogToFile(false, true);
            IO.Output(seconds);
            Console.ReadKey();
        }
    }
}
