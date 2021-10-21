using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    class Light
    {
        Vector2 position, velocity;

        public Light(string info)
        {
            string[] posInfo = info.Split('<')[1].Split('>')[0].Split(',');
            string[] velInfo = info.Split('<')[2].Split('>')[0].Split(',');

            position = new Vector2(int.Parse(posInfo[0]), int.Parse(posInfo[1]));
            velocity = new Vector2(int.Parse(velInfo[0]), int.Parse(velInfo[1]));
        }

        
        public void Update()
        {
            position += velocity;
        }

        public Vector2 Position { get { return position; } }


    }
}
