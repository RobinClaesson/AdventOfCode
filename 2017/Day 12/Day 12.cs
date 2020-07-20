using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            //Part 1
            IO.Output(Group(input, 0).Count);

            //Part 2
            HashSet<HashSet<int>> groups = new HashSet<HashSet<int>>();
            for (int i = 0; i < input.Count; i++)
            {
                bool inGroup = false;
                foreach (HashSet<int> group in groups)
                    if (group.Contains(i))
                        inGroup = true;

                if (!inGroup)
                    groups.Add(Group(input, i));
            }

            IO.Output(groups.Count);
            Console.ReadKey();
        }


        static HashSet<int> Group(List<string> input, int root)
        {
            Queue<int> q = new Queue<int>();
            HashSet<int> s = new HashSet<int>();

            if (input.Count <= root)
                return s;

            q.Enqueue(root);
            s.Add(root);

            while (q.Count > 0)
            {
                int p = q.Dequeue();

                string[] connections = input[p].Split('>')[1].Replace(" ", "").Split(',');

                foreach (string connectsTO in connections)
                {
                    int c = int.Parse(connectsTO);

                    if (!s.Contains(c))
                    {
                        q.Enqueue(c);
                        s.Add(c);
                    }
                }
            }

            return s;
        }

    }
}
