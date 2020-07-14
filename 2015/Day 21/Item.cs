using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
    class Item
    {
        public int cost;
        public int dmgBonus;
        public int armorBonus;

        public Item(int cost, int dmgBonus, int armorBonus)
        {
            this.cost = cost;
            this.dmgBonus = dmgBonus;
            this.armorBonus = armorBonus;
        }
    }
}
