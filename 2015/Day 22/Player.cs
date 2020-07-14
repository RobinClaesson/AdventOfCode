using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
    class Player
    {
        //TODO: If it fails, try having max Hp that drain cant go over?
        int hp, mana;

        int manaSpent;

        int shieldTimer;
        int rechargeTimer;

        int hpLostPerRound;

        public int HP { get { return hp; } }
        public int Mana { get { return mana; } }

        public int ManaSpent { get { return manaSpent; } }

        //Player for testing
        public Player(int hp, int mana, int hpLostPerRound)
        {
            this.hp = hp;
            this.mana = mana;

            manaSpent = 0;

            shieldTimer = 0;
            rechargeTimer = 0;

            this.hpLostPerRound = hpLostPerRound;
        }

        //Standard player to use in answer
        public Player(int hpLostPerRound)
        {
            hp = 50;
            mana = 500;

            manaSpent = 0;

            shieldTimer = 0;
            rechargeTimer = 0;

            this.hpLostPerRound = hpLostPerRound;
        }


        //Copying a player
        public Player(Player ToCopy)
        {
            this.hp = ToCopy.hp;
            this.mana = ToCopy.mana;

            manaSpent = ToCopy.manaSpent;

            shieldTimer = ToCopy.shieldTimer;
            rechargeTimer = ToCopy.rechargeTimer;

            this.hpLostPerRound = ToCopy.hpLostPerRound;
        }



        //If a player can cast the chosen spell
        public bool CanCastSpell(Spell spell)
        {
            bool canCast = true;

            if (mana < spell.ManaCost)
                canCast = false;

            else if (spell is Shield && shieldTimer > 0)
                canCast = false;

            else if (spell is Recharge && rechargeTimer > 0)
                canCast = false;

            
            return canCast;
        }

        //Effects on the player when casting spells
        public void CastSpell(Spell spell)
        {
            if(spell is Shield)
            {
                shieldTimer = spell.TimerLength;                
            }

            else if(spell is Drain)
            {
                hp += spell.Value;
            }

            else if(spell is Recharge)
            {
                rechargeTimer = spell.TimerLength;
            }


            SpendMana(spell.ManaCost);
        }

        
        private void SpendMana(int manaToSpend)
        {
            mana -= manaToSpend;
            manaSpent += manaToSpend;
        }

        //Update
        public void UpdateTimers()
        {
            if (shieldTimer > 0)
                shieldTimer--;

            if (rechargeTimer > 0)
            {
                rechargeTimer--;
                mana += new Recharge().Value;
            }
        }


        //Damage and hp-checks
        public bool IsDead()
        {
            if (hp > 0)
                return false;

            else return true;
        }
        
        public bool DiesFromRoundHpLost()
        {
            hp -= hpLostPerRound;
            
            return IsDead();
        }

        public bool DiesFromAttack(int attackDamage)
        {
            int armor = 0;

            if (shieldTimer > 0)
                armor = new Shield().Value;

            int dmg = attackDamage - armor;

            if (dmg < 1)
                dmg = 1;

            hp -= dmg;

            return IsDead();
        }

        
    }
}
