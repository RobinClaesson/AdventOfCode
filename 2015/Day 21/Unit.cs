using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
    class Unit
    {
        public int hp;
        public int armor;
        public int damage;
        public int totalCost = 0;

        public Unit(int hp, int damage, int armor, List<Item> items)
        {
            this.hp = hp;
            this.armor = armor;
            this.damage = damage;

            totalCost = 0;
            if (items != null)
                foreach (Item item in items)
                {
                    totalCost += item.cost;
                    this.damage += item.dmgBonus;
                    this.armor += item.armorBonus;
                }
        }

        public Unit(Unit template)
        {
            this.hp = template.hp;
            this.armor = template.armor;
            this.damage = template.damage;
        }

        public void TakeDamage(int attackerDmg)
        {
            int dmg = attackerDmg - armor;
            if (dmg < 1)
                dmg = 1;

            hp -= dmg;
            if (hp < 0)
                hp = 0;
        }
    }
}
