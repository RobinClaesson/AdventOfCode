using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23
{
    class Register
    {
        long currentInstruction = 0;
        int timesMul = 0;
        long updates = 0, highestInstruction;

        bool running = true;
        public int CurrentInstruction { get { return (int)currentInstruction; } set { currentInstruction = value; } }
        public int TimesMul { get { return timesMul; } }

        public long UpdatesDone { get { return updates; } }


        public bool Running { get { return running && currentInstruction != instructions.Length; } }

        Dictionary<char, long> register = new Dictionary<char, long>();
        string[] instructions;
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
        public Register(List<string> instructions, int a)
        {
            this.instructions = new string[instructions.Count];
            instructions.CopyTo(this.instructions);

            register.Add('a', a);
        }

        public void Update()
        {
            DoInstruction(instructions[currentInstruction]);

            if (currentInstruction > highestInstruction)
                highestInstruction = currentInstruction;

            updates++;
        }

        public void DoInstruction(string instruction)
        {
            string[] words = instruction.Split(' ');

            char reg = words[1].First();

            if (words[0] == "set")
            {
                if (int.TryParse(words[2], out int result))
                    Set(reg, result);

                else
                    Set(reg, words[2].First());
            }

            else if (words[0] == "sub")
            {
                if (int.TryParse(words[2], out int result))
                    Sub(reg, result);

                else
                    Sub(reg, words[2].First());
            }

            else if (words[0] == "mul")
            {
                if (int.TryParse(words[2], out int result))
                    Mul(reg, result);

                else
                    Mul(reg, words[2].First());
            }

            else if (words[0] == "jnz")
            {
                int value = int.Parse(words[2]);

                if (int.TryParse(words[1], out int result))
                    Jump(result, value);
                else
                    Jump(words[1].First(), value);
            }

        }

        private void CheckReg(char reg)
        {
            if (!register.ContainsKey(reg))
                register.Add(reg, 0);
        }
        public override string ToString()
        {
            string s = "";

            foreach (char key in register.Keys)
                s += key + ": " + register[key] + "\r\n";
            s += "Current Instruction: " + currentInstruction + "\r\n";

            s += instructions[currentInstruction] + "\r\n";

            //s += "Running: " + running;

            s += "\r\nHighest Instruction: " + highestInstruction + "\r\n" + instructions[highestInstruction];


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
            CheckReg(getValueFrom);

            Add(addTo, register[getValueFrom]);
        }

        public void Sub(char subTo, long value)
        {
            Add(subTo, -value);
        }

        public void Sub(char subTo, char getValueFrom)
        {
            CheckReg(getValueFrom);

            Sub(subTo, register[getValueFrom]);
        }

        public void Mul(char mulTo, long value)
        {
            CheckReg(mulTo);

            register[mulTo] *= value;

            timesMul++;

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
            if (checkValue != 0)
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

    }
}
