using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    class Marbles
    {
        /// <summary>
        /// Internal linked list node class
        /// </summary>
        private class Marble
        {
            public Marble Next { get; set; }
            public Marble Prev { get; set; }
            public int Value { get; set; }
        }

        Marble current, first;

        public Marbles()
        {
            current = new Marble();
            current.Next = current;
            current.Prev = current;
            current.Value = 0;

            first = current;
        }

        /// <summary>
        /// Adds a marble to the circle and returns any points awarded 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Potential score from placing marble, -1 if no points awarded</returns>
        public int AddMarble(int value)
        {
            //Gets score
            if(value % 23 == 0)
            {
                int score = value;

                Marble toRemove = current;
                for (int i = 0; i < 7; i++)
                    toRemove = toRemove.Prev;

                score += toRemove.Value;

                toRemove.Prev.Next = toRemove.Next;
                toRemove.Next.Prev = toRemove.Prev;
                current = toRemove.Next;

                return score;
            }


            //Adds new marble
            Marble m = new Marble();
            m.Value = value;

            m.Next = current.Next.Next;
            m.Prev = current.Next;
            m.Prev.Next = m;
            m.Next.Prev = m;

            current = m;
            return -1;
        }
        /// <summary>
        /// Prints marble circle from start to end circling in the current marble
        /// </summary>
        public void Print()
        {
            Marble iterate = first;

            do
            {

                if (iterate == current)
                    Console.Write("(" + iterate.Value + ") ");
                else
                    Console.Write(iterate.Value + " ");
                iterate = iterate.Next;

            } while (iterate != first);

            Console.WriteLine();
        }
    }
}
