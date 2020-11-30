using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;
namespace Day_17
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<int> containters = IO.InputRows_Int;
            containters.Sort();

            int litersToFill = 150;


            List<List<int>> combos = GetCombinations(containters);

            //Part 1
            
            int fills = 0;

            foreach (List<int> combo in combos)
                if (combo.Sum() == litersToFill)
                    fills++;

            IO.Output(fills);


            //Part 2
            
            fills = 0;
            int minBuckets = int.MaxValue;

            foreach (List<int> combo in combos)
            {
                if (combo.Sum() == litersToFill)
                {
                    if (combo.Count < minBuckets)
                    {
                        fills = 1;
                        minBuckets = combo.Count;
                    }
                    else if (combo.Count == minBuckets)
                        fills++;
                }
            }


            IO.Output(fills, true);
            Console.ReadKey();
        }

        static List<List<int>> GetCombinations(List<int> list)
        {
            List<List<int>> combos = new List<List<int>>();

            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                List<int> combo = new List<int>();
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');

                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        combo.Add(list[j]);
                    }
                }

                combos.Add(combo);
            }

            return combos;
        }
    }
}
