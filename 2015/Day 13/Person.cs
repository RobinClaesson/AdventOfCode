using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
    class Person
    {
        public string name;
        Hashtable comfortWith = new Hashtable();

        public Person(string name)
        {
            this.name = name;
        }

        public void AddComfortRule(string person, int value)
        {
            comfortWith.Add(person, value);
        }

        public int GetComfortWith(string person)
        {
            if (comfortWith.ContainsKey(person))
                return (int)comfortWith[person];
            else return 0;
        }
    }
}
