using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
    
    abstract class Spell
    {
        protected int manaCost;
        protected int value;
        protected int timerLength;
        string name;

        public string Name { get { return name; } }

        public int ManaCost { get { return manaCost; } }
        public int Value {  get { return value; } }
        public int TimerLength { get { return timerLength; } }


        protected Spell(string name, int manaCost, int value, int timerLength)
        {
            this.name = name;
            this.manaCost = manaCost;
            this.value = value;
            this.timerLength = timerLength;
        }
    }

    
}
