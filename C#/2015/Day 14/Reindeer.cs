using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    class Reindeer
    {
        int speed, durability, restLength, tick, distance, points;

        public Reindeer(int speed, int durability, int restLength)
        {
            this.speed = speed;
            this.durability = durability;
            this.restLength = restLength;
            Reset();
        }

        public void Update()
        {
            tick++;

            if (tick <= durability)
                distance += speed;

            if (tick >= durability + restLength)
                tick = 0;            
        }

        public void AwardPoint()
        {
            points++;
        }

        public void Reset()
        {
            distance = 0;
            tick = 0;
            points = 0;
        }

        public int DistanceTravled { get { return distance; } }
        public int Points { get { return points; } }
    }
}
