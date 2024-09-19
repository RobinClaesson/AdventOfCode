using System.Text;

namespace AoC2019Libraries
{
    public class IntCodeComputer
    {
        private List<int> program = new List<int>();
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

        public void Run()
        {
            while (program[instructionPointer] != 99)
            {
                switch (program[instructionPointer])
                {
                    case 1:
                        Opcode1();
                        break;
                    case 2:
                        Opcode2();
                        break;
                    default:
                        throw new Exception("Invalid opcode");
                }

            }
        }

        private void Opcode1()
        {
            var a = program[instructionPointer + 1];
            var b = program[instructionPointer + 2];
            var to = program[instructionPointer + 3];
            program[to] = program[a] + program[b];
            instructionPointer += 4;
        }

        private void Opcode2()
        {
            var a = program[instructionPointer + 1];
            var b = program[instructionPointer + 2];
            var to = program[instructionPointer + 3];
            program[to] = program[a] * program[b];
            instructionPointer += 4;
        }
    }
}
