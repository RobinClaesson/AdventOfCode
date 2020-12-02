using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Day_20
{
    class Particle
    {
        public Vector3 p, v, a;
        public bool alive = true;
        public Particle(string data)
        {
            data = data.Replace("<","");
            data = data.Replace(">", "");
            data = data.Replace("=", "");
            data = data.Replace("p", "");
            data = data.Replace("a", "");
            data = data.Replace("v", "");
            data = data.Replace(" ", "");

            string[] values = data.Split(',');

            p = new Vector3(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
            v = new Vector3(int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]));
            a = new Vector3(int.Parse(values[6]), int.Parse(values[7]), int.Parse(values[8]));

        }

        public void Update()
        {
            if (alive)
            {
                v.X += a.X;
                v.Y += a.Y;
                v.Z += a.Z;

                p.X += v.X;
                p.Y += v.Y;
                p.Z += v.Z;
            }
        }

        public float ManhattanDist
        {
            get
            {
                return Math.Abs(p.X) + Math.Abs(p.Y) + Math.Abs(p.Z);
            }
        }
    }
}
