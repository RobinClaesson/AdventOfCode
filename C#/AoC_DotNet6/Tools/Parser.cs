using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Tools
{
    public class Parser
    {
        public static Vector2 ParseVector2(string s)
        {
            var split = s.Split(',');
            return new Vector2(float.Parse(split[0]), float.Parse(split[1]));
        } 
    }
}
