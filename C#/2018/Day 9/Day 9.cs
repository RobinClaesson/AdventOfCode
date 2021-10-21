using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input: 452 players; last marble is worth 71250 points


            int numOfPlayers = 452;
            int lastMarble = 71250;

            Marbles marbles = new Marbles();
            long[] players = new long[numOfPlayers];
            int currentPlayer = 0;

            for (int i = 1; i <= lastMarble; i++)
            {
                int score = marbles.AddMarble(i);

                if (score != -1)
                    players[currentPlayer] += score;

                currentPlayer++;
                if (currentPlayer >= players.Length)
                    currentPlayer = 0;

                //marbles.Print();
            }

            IO.Output(players.Max());

            for (int i = lastMarble + 1; i <= lastMarble * 100; i++)
            {
                int score = marbles.AddMarble(i);

                if (score != -1)
                    players[currentPlayer] += score;

                currentPlayer++;
                if (currentPlayer >= players.Length)
                    currentPlayer = 0;

                //marbles.Print();
            }

            IO.Output(players.Max());
            Console.ReadKey();
        }
    }
}
