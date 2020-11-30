using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
    class Boss
    {
        int hp, damage;

        int poisonTimer;

        public int AttackDamage { get { return damage; } }
        public int HP { get { return hp; } }

        public Boss(int hp, int damage)
        {
            this.hp = hp;
            this.damage = damage;

            poisonTimer = 0;
        }


        public Boss(Boss toCopy)
        {
            this.hp = toCopy.hp;
            this.damage = toCopy.damage;

            this.poisonTimer = toCopy.poisonTimer;
        }

        public bool IsPoisoned { get { return (poisonTimer > 0); } }

        public bool IsDead()
        {
            if (hp > 0)
                return false;

            else return true;
        }

        public bool DiesFromPoison()
        {
            if (poisonTimer > 0)
            {
                poisonTimer--;

                return DiesFromDamage(new Poison().Value);
            }

            else return false;

        }

        public bool DiesFromSpell(Spell spell)
        {
            if (spell is Poison)
            {
                poisonTimer = new Poison().TimerLength;
                return false;
            }

            else if (spell is Drain || spell is MagicMissile)
            {
                return DiesFromDamage(spell.Value);
            }

            else return false;

        }

        private bool DiesFromDamage(int dmgDelt)
        {
            hp -= dmgDelt;

            return IsDead();
        }
    }
}
