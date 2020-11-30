using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_13
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> input = IO.InputRows;

            List<Person> people = new List<Person>();
            List<string> names = new List<string>();
            foreach (string row in input)
            {
                string name = row.Split(' ')[0];

                if (!HasPerson(people, name))
                {
                    people.Add(new Person(name));
                    names.Add(name);
                }


                int value = int.Parse(row.Split(' ')[3]);
                if (row.Split(' ')[2] == "lose")
                    value *= -1;

                string otherName = row.Split(' ')[10];
                otherName = otherName.Substring(0, otherName.Length - 1);
                people[PersonIndex(people, name)].AddComfortRule(otherName, value);
            }


            IO.Output(CalculateSeating(people, names));

            //Part 2
            

            names.Add("Me");
            people.Add(new Person("Me"));

            IO.Output(CalculateSeating(people, names), true);

            Console.ReadKey();


        }

        private static int CalculateSeating(List<Person> people, List<string> names)
        {
            
            List<string> seatings = GetSeatings(names);

            int maxHappieness = int.MinValue;

            foreach (string seating in seatings)
            {
                int happieness = 0;
                string[] seatingArray = seating.Split(' ');

                //happieness for the first person with the last and second person
                happieness += people[PersonIndex(people, seatingArray[0])].GetComfortWith(seatingArray[seatingArray.Length - 1]);
                happieness += people[PersonIndex(people, seatingArray[0])].GetComfortWith(seatingArray[1]);

                //Happieness for everyone else but the last person
                for (int i = 1; i < seatingArray.Length - 1; i++)
                {
                    happieness += people[PersonIndex(people, seatingArray[i])].GetComfortWith(seatingArray[i + 1]);
                    happieness += people[PersonIndex(people, seatingArray[i])].GetComfortWith(seatingArray[i - 1]);
                }

                //Happieness with the last person
                happieness += people[PersonIndex(people, seatingArray[seatingArray.Length - 1])].GetComfortWith(seatingArray[0]);
                happieness += people[PersonIndex(people, seatingArray[seatingArray.Length - 1])].GetComfortWith(seatingArray[seatingArray.Length - 2]);

                if (happieness > maxHappieness)
                    maxHappieness = happieness;
            }

            return maxHappieness;
            
        }

        static List<string> GetSeatings(List<string> names)
        {
            List<string> seatings = new List<string>();

            if (names.Count == 1)
                seatings.Add(names[0]);
            else
            {
                for (int i = 0; i < names.Count; i++)
                {
                    string s = names[i];

                    //Creates a list of names without our first
                    List<string> otherNames = new List<string>();
                    for (int j = 0; j < names.Count; j++)
                        if (i != j)
                            otherNames.Add(names[j]);


                    List<string> permutationsAfter = GetSeatings(otherNames);

                    for (int j = 0; j < permutationsAfter.Count; j++)
                        seatings.Add(s + " " + permutationsAfter[j]);

                }
            }


            return seatings;
        }

        static bool HasPerson(List<Person> people, string name)
        {
            foreach (Person person in people)
                if (name == person.name)
                    return true;

            return false;
        }

        static int PersonIndex(List<Person> people, string name)
        {
            for (int i = 0; i < people.Count; i++)
                if (name == people[i].name)
                    return i;

            return -1;
        }
    }
}
