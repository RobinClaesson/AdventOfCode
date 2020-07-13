using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Day_16
{
    class Sue
    {
        Hashtable items = new Hashtable();

        public Sue(bool isGiver)
        {
            if (isGiver)
            {
                items.Add("children", "3");
                items.Add("cats", "7");
                items.Add("samoyeds", "2");
                items.Add("pomeranians", "3");
                items.Add("akitas", "0");
                items.Add("vizslas", "0");
                items.Add("goldfish", "5");
                items.Add("trees", "3");
                items.Add("cars", "2");
                items.Add("perfumes", "1");
            }
        }

        public void SetItemCount(string item, string count)
        {
            if (items.ContainsKey(item))
                items[item] = count;
            else
                items.Add(item, count);
        }

        public string GetCount(object item)
        {
            if (items.ContainsKey(item))
                return (string)items[item];

            return "unknown";
        }

        public int GetCountValue(object item)
        {
            if (items.ContainsKey(item))
                return int.Parse((string)items[item]);

            return -1;
        }

        public bool Matches(Sue other)
        {
            foreach (object key in items.Keys)
            {
                if (GetCount(key) != other.GetCount(key) && other.GetCount(key) != "unknown")
                    return false;
            }

            return true;
        }

        public bool Matches2(Sue other)
        {
            foreach (object key in items.Keys)
            {

                if (other.GetCountValue(key) != -1)
                {
                    string keyString = (string)key;

                    if (keyString == "cats" || keyString == "trees")
                    {
                        if (GetCountValue(key) >= other.GetCountValue(key))
                            return false;
                    }

                    else if (keyString == "pomeranians" || keyString == "goldfish")
                    {
                        if (GetCountValue(key) <= other.GetCountValue(key))
                            return false;
                    }

                    else if(GetCount(key) != other.GetCount(key))
                    return false;
                }

            }

            return true;
        }
    }
}
