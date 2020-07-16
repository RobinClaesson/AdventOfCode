using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            int supports = 0;
            foreach (string row in input)
            {
                if (SupportsTLS(row))
                    supports++;
            }

            IO.Output(supports);

            //Part 2
            supports = 0;
            foreach (string row in input)
            {
                if (SupportsSSL(row))
                    supports++;
            }

            IO.Output(supports);

            Console.ReadKey();
        }

        private static bool SupportsTLS(string ip)
        {
            ip = ip.Replace("[", "-");
            ip = ip.Replace("]", "-");

            string[] sections = ip.Split('-');

            bool hasOutside = false, hasInside = false;

            for (int i = 0; i < sections.Length; i++)
            {
                if (HasAbba(sections[i]))
                {
                    if (i % 2 == 0)
                        hasOutside = true;
                    else
                        hasInside = true;
                }
            }

            return hasOutside && !hasInside;
        }

        private static bool SupportsSSL(string ip)
        {
            ip = ip.Replace("[", "-");
            ip = ip.Replace("]", "-");

            string[] sections = ip.Split('-');

            List<string> foundABA = new List<string>();

            //looks through all sections outside the brackets
            for(int i = 0; i< sections.Length; i+= 2)
            {
                List<string> aba = GetABA(sections[i]);

                if (aba.Count > 0)
                    foundABA.AddRange(aba);
            }

            if (foundABA.Count == 0)
                return false;

            //looks through all secitions inside the brackets
            for (int i = 1; i < sections.Length; i += 2)
            {
                foreach(string aba in foundABA)
                {
                    string bab = ""+ aba[1] + aba[0] + aba[1];

                    if (sections[i].Contains(bab))
                        return true;
                }
            }


            return false;
        }

        private static bool HasAbba(string s)
        {
            for (int i = 0; i < s.Length - 3; i++)
            {
                if (s[i] != s[i + 1] && s[i] == s[i + 3] && s[i + 1] == s[i + 2])
                    return true;
            }

            return false;
        }

        private static List<string> GetABA(string s)
        {
            List<string> aba = new List<string>();
            char[] c = s.ToCharArray();
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (c[i] != c[i + 1] && c[i] == c[i + 2])
                    aba.Add( "" + c[i] + c[i + 1] + c[i + 2]);
            }

            return aba;
        }
    }
}
