using System.Text;
using System.Linq;

namespace AoC2019Libraries
{
    public class IntCodeComputer
    {
        private List<int> program = new List<int>();
        private Queue<int> inputs = new Queue<int>();
        private Queue<int> outputs = new Queue<int>();

        private int instructionPointer = 0;

        public IntCodeComputer(IEnumerable<int> program)
        {
            this.program = program.ToList();
        }

        public IntCodeComputer(IEnumerable<int> program, int noun, int verb)
        {
            this.program = program.ToList();
            this.program[1] = noun;
            this.program[2] = verb;
        }

        public int this[int index]
        {
            get { return program[index]; }
            set { program[index] = value; }
        }

        public override string ToString()
            => string.Join(",", program);

        public void AddInput(int input)
            => inputs.Enqueue(input);

        public void AddInputs(IEnumerable<int> inputs)
            => inputs.ToList().ForEach(this.inputs.Enqueue);

        public int GetOutput()
            => outputs.Dequeue();

        public void Run()
        {
            while (program[instructionPointer] != 99)
            {
                var opcode = program[instructionPointer] % 100;
                var paramModes = (program[instructionPointer] / 100).ToString()
                                                                    .PadLeft(3, '0')
                                                                    .Select(c => int.Parse($"{c}"))
                                                                    .Reverse()
                                                                    .ToArray();

                switch (opcode)
                {
                    case 1:
                        Opcode1(paramModes);
                        break;
                    case 2:
                        Opcode2(paramModes);
                        break;
                    case 3:
                        OpCode3();
                        break;
                    case 4:
                        OpCode4(paramModes);
                        break;
                    default:
                        throw new Exception("Invalid opcode");
                }

            }
        }

        private int GetParameterValue(int paramIndex, int[] paramModes)
        {
            var param = program[instructionPointer + paramIndex + 1];
            if (paramModes[paramIndex] == 0) // position mode
            {
                return program[param];
            }
            else // immediate mode
            {
                return param;
            }
        }

        private void Opcode1(int[] paramModes)
        {
            var a = GetParameterValue(0, paramModes);
            var b = GetParameterValue(1, paramModes);
            var to = program[instructionPointer + 3]; //Parameters that an instruction writes to will never be in immediate mode
            program[to] = a + b;
            instructionPointer += 4;
        }

        private void Opcode2(int[] paramModes)
        {
            var a = GetParameterValue(0, paramModes);
            var b = GetParameterValue(1, paramModes);
            var to = program[instructionPointer + 3]; //Parameters that an instruction writes to will never be in immediate mode
            program[to] = a * b;
            instructionPointer += 4;
        }

        private void OpCode3()
        {
            var to = program[instructionPointer + 1];
            program[to] = inputs.Dequeue();
            instructionPointer += 2;
        }

        private void OpCode4(int[] paramModes)
        {
            var output = GetParameterValue(0, paramModes);
            outputs.Enqueue(output);
            instructionPointer += 2;
        }
    }
}
