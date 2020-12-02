using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_18_v2
{
    class Register
    {
        long playedSound;
        long recoverdSound = 0;
        long currentInstruction = 0;
        int timesPlayed = 0;

        bool running = true;

        Queue<long> recoverQue = new Queue<long>();

        public long LastPlayedSound { get { return playedSound; } /*set { playedSound = value; }*/ }
        public int CurrentInstruction { get { return (int)currentInstruction; } set { currentInstruction = value; } }
        public long RecoverdSound { get { return recoverdSound; } }
        public int TimesPlayed { get { return timesPlayed; } }

        public bool Running { get { return running && currentInstruction != 40; } }

        Dictionary<char, long> register = new Dictionary<char, long>();

        public long GetValue(char reg)
        {
            if (register.ContainsKey(reg))
                return register[reg];
            else
            {
                register.Add(reg, 0);
                return 0;
            }
        }
        public Register()
        {

        }

        public Register(int index)
        {
            register.Add('p', index);

           
        }

        private void CheckReg(char reg)
        {
            if (!register.ContainsKey(reg))
                register.Add(reg, 0);
        }


        public void Play(long value)
        {
            playedSound = value;

            timesPlayed++;
            currentInstruction++;
        }

        public void Play(char playFrom)
        {
            CheckReg(playFrom);

            Play(register[playFrom]);
        }

        public void Play(char playFrom, Register playTo)
        {
            Play(playFrom);

            playTo.EnqueSound(playedSound);
        }
        public void Play(long value, Register playTo)
        {
            Play(value);

            playTo.EnqueSound(playedSound);
        }

        

        public override string ToString()
        {
            string s = "";

            foreach (char key in register.Keys)
                s += key + ": " + register[key] + "\r\n";
            s += "Current Instruction: " + currentInstruction + "\r\n";

            s += "Recover Cue: ";
            foreach (int q in recoverQue)
                s += q + " ";

            s += "\r\nRunning: " + running;

            return s;
        }

        public void Set(char saveTo, long value)
        {
            CheckReg(saveTo);

            register[saveTo] = value;

            currentInstruction++;
        }
        public void Set(char saveTo, char getValueFrom)
        {
            CheckReg(saveTo);
            CheckReg(getValueFrom);

            Set(saveTo, register[getValueFrom]);
        }
        public void Add(char addTo, long value)
        {
            CheckReg(addTo);

            register[addTo] += value;

            currentInstruction++;
        }

        public void Add(char addTo, char getValueFrom)
        {
            CheckReg(addTo);
            CheckReg(getValueFrom);

            Add(addTo, register[getValueFrom]);
        }

        public void Mul(char mulTo, long value)
        {
            CheckReg(mulTo);

            register[mulTo] *= value;


            currentInstruction++;
        }

        public void Mul(char mulTo, char getValueFrom)
        {
            CheckReg(mulTo);
            CheckReg(getValueFrom);

            Mul(mulTo, register[getValueFrom]);
        }

        public void Mod(char modTo, long value)
        {
            CheckReg(modTo);

            register[modTo] %= value;

            currentInstruction++;
        }

        public void Mod(char modTo, char getValueFrom)
        {
            CheckReg(modTo);
            CheckReg(getValueFrom);

            Mod(modTo, register[getValueFrom]);
        }

        public void Jump(long checkValue, long value)
        {
            if(checkValue > 0)
                currentInstruction += value;
            else
                currentInstruction++;
        }

        public void Jump(char reg, long value)
        {
            CheckReg(reg);
            Jump(register[reg], value);
        }

        public void Jump(char reg, char getValueFrom)
        {
            CheckReg(reg);
            CheckReg(getValueFrom);

            Jump(reg, register[getValueFrom]);
        }

        public void RecoverOwn(char reg)
        {
            CheckReg(reg);

            if (register[reg] != 0)
            {
                recoverdSound = LastPlayedSound;
            }

            currentInstruction++;
        }

        public void Recover(char saveTo)
        {
            if (recoverQue.Count > 0)
            {
                Set(saveTo, recoverQue.Dequeue());
                running = true;
            }
            else
                running = false;
        }

        public void EnqueSound(long value)
        {
            recoverQue.Enqueue(value);
        }



    }
}
