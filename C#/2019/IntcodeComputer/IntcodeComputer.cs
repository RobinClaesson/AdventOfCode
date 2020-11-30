using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace IntcodeComputer
{
    public class Computer
    {
        protected List<long> _program = new List<long>(), _baseProgram;
        protected int _programPosition, _input, _lastOpcode, _relativeBase;
        protected long _output;
        protected bool _debug = false;

        public long Output { get { return _output; } }
        //public int LastOpCode { get { return _lastOpcode; } }

        public bool Finished
        {
            get
            {
                if (_lastOpcode == 99)
                    return true;
                else
                    return false;
            }
        }

        public int Input { set { _input = value; } }

        public Computer(List<long> program, int input)
        {
            _baseProgram = program;
            Reset();

            _input = input;
        }
        public Computer(List<long> program)
        {
            _baseProgram = program;
            Reset();


            _input = 0;
        }

        public void Reset()
        {
            _program.Clear();
            _programPosition = 0;
            _lastOpcode = -1;
            _relativeBase = 0;

            for (int i = 0; i < 10000000; i++)
            {
                if (i < _baseProgram.Count)
                    _program.Add(_baseProgram[i]);

                else
                    _program.Add(0);
            }
        }


        public void ComputeStep()
        {
            string instruction = "" + _program[_programPosition];

            //Adding 0s to make all instructions the same predictable length
            //as any missing numbers should be interperted as 0 anyways
            while (instruction.Length < 5)
                instruction = "0" + instruction;


            //The opcode is the last two characters in the instruction, the other 3 are parametermodes
            int opcode = int.Parse(instruction.Substring(instruction.Length - 2));

            //The parameters are read right to left so we flip the list to make it easier from here on
            List<char> parModes = instruction.Substring(0, instruction.Length - 2).ToList<char>();
            parModes.Reverse();


            //Invokes the Opcode that is called
            string functionName = "Opcode" + opcode;
            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(functionName, BindingFlags.NonPublic | BindingFlags.Instance);
            theMethod.Invoke(this, new object[] { parModes });




            _lastOpcode = opcode;

            if (_debug)
            {
                Console.WriteLine("-----------------------------");
                Console.ReadKey();
            }
        }

        public void ComputeToEnd()
        {
            _debug = false;
            do
            {
                ComputeStep();
            } while (_lastOpcode != 99);
        }

        public void ComputeToEnd(bool printOutputs, bool debug)
        {
            _debug = debug;
            do
            {
                ComputeStep();
                if (printOutputs && _lastOpcode == 4)
                    Console.WriteLine(_output);
            } while (_lastOpcode != 99);

        }

        public void ComputeToOutput()
        {
            do
            {
                ComputeStep();
            }
            while (_lastOpcode != 99 && _lastOpcode != 4);
        }


        private long[] GetValues(List<char> parModes, int numOfValues)
        {
            long[] values = new long[numOfValues];

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = _program[GetAdress(parModes, i + 1)];

                if (_debug)
                    Console.WriteLine("Gets value " + values[i] + " from adress " + GetAdress(parModes, i + 1));
            }

            return values;
        }

        private int GetAdress(List<char> parModes, int adressParamIndex)
        {
            //Position mode
            if (parModes[adressParamIndex - 1] == '0')
                return (int)_program[_programPosition + adressParamIndex];

            //Immediate mode
            else if (parModes[adressParamIndex - 1] == '1')
                return _programPosition + adressParamIndex;

            //Relative mode
            else if (parModes[adressParamIndex - 1] == '2')
                return (int)_program[_programPosition + adressParamIndex] + _relativeBase;

            else
                return -1;
        }

        private void SaveToAdress(int adress, long value)
        {
            _program[adress] = value;
        }


        //Opcodes 
        private void Opcode1(List<char> parModes)
        {
            long[] terms = GetValues(parModes, 2);

            if (_debug)
                Console.WriteLine("Opcode 1: Saving " + terms[0] + "+" + terms[1] + " to adress" + GetAdress(parModes, 3));

            SaveToAdress(GetAdress(parModes, 3), terms[0] + terms[1]);
            _programPosition += 4;
        }

        private void Opcode2(List<char> parModes)
        {
            long[] factors = GetValues(parModes, 2);

            if (_debug)
                Console.WriteLine("Opcode 2: Saving " + factors[0] + "*" + factors[1] + " to adress" + GetAdress(parModes, 3));

            SaveToAdress(GetAdress(parModes, 3), factors[0] * factors[1]);
            _programPosition += 4;
        }

        private void Opcode3(List<char> parModes)
        {

            if (_debug)
                Console.WriteLine("Opcode 3: Saving " + _input + " to adress" + GetAdress(parModes, 1));

            SaveToAdress(GetAdress(parModes, 1), _input);
            _programPosition += 2;
        }

        private void Opcode4(List<char> parModes)
        {
            if (_debug)
                Console.WriteLine("Opcode 4: Outputs " + GetValues(parModes, 1)[0]);

            _output = GetValues(parModes, 1)[0];
            _programPosition += 2;
        }

        private void Opcode5(List<char> parModes)
        {
            long[] values = GetValues(parModes, 2);

            if (values[0] != 0)
            {
                if (_debug)
                    Console.WriteLine("Opcode 5: " + values[0] + " is not 0, jumping to programposition " + values[1]);

                _programPosition = (int)values[1];
            }

            else
            {
                if (_debug)
                    Console.WriteLine("Opcode 5: " + values[0] + " is 0, continuing program");
                _programPosition += 3;
            }
                
        }

        private void Opcode6(List<char> parModes)
        {
            long[] values = GetValues(parModes, 2);

            if (values[0] == 0)
            {
                if(_debug)
                    Console.WriteLine("Opcode 6: " + values[0] + " is 0, jumping to programposition " + values[1]);
                _programPosition = (int)values[1];
            }

            else
            {
                if (_debug)
                    Console.WriteLine("Opcode 6: " + values[0] + " is not 0, continuing program");
                _programPosition += 3;
            }
        }

        private void Opcode7(List<char> parModes)
        {
            long[] values = GetValues(parModes, 2);

            if (_debug)
                Console.WriteLine("Opcode 7: " + values[0] + "<" + values[1] + " = " + (values[0] < values[1]) + ". Writing " + Convert.ToInt32(values[0] < values[1]) + " to adress " + GetAdress(parModes, 3));

            SaveToAdress(GetAdress(parModes, 3), Convert.ToInt32(values[0] < values[1]));
            _programPosition += 4;
        }

        private void Opcode8(List<char> parModes)
        {
            long[] values = GetValues(parModes, 2);

            if (_debug)
                Console.WriteLine("Opcode 8: " + values[0] + "==" + values[1] + " = " + (values[0] == values[1]) + ". Writing " + Convert.ToInt32(values[0] == values[1]) + " to adress " + GetAdress(parModes, 3));

            SaveToAdress(GetAdress(parModes, 3), Convert.ToInt32(values[0] == values[1]));
            _programPosition += 4;
        }

        private void Opcode9(List<char> parModes)
        {
            if (_debug)
                Console.WriteLine("Opcode 9: Increases relative base by " + (int)GetValues(parModes, 1)[0]);
            _relativeBase += (int)GetValues(parModes, 1)[0];

            _programPosition += 2;
        }

        private void Opcode99(List<char> parModes)
        {
            //The Program just exits
        }



    }
}
