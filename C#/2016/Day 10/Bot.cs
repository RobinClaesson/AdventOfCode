using Microsoft.SqlServer.Server;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    class Bot
    {
        List<int> chips = new List<int>();
        string lowOutputPlace = "", highOutputPlace = "";

        bool hasMoved = false;

        public string LowOutputPlace { get { return lowOutputPlace; } set { lowOutputPlace = value; } }
        public string HighOutputPlace { get { return highOutputPlace; } set { highOutputPlace = value; } }

        public int LowOutput
        {
            get
            {
                return chips.Min();
            }
        }

        public int HighOutput
        {
            get
            {
                return chips.Max();
            }
        }

        public bool HasMoved { get { return hasMoved; } set { hasMoved = true; } }

        public bool CanMove { get { return chips.Count == 2; } }

        public Bot()
        {

        }

        public void Input(int value)
        {
            chips.Add(value);
        }

        public bool HasChip(int value)
        {
            return chips.Contains(value);
        }

        public bool HasBothChips(int value1, int value2)
        {
            return HasChip(value1) && HasChip(value2);
        }
    }
}
