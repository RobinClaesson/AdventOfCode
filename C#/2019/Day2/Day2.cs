using AoC.IO;
using AoC2019Libraries;

Input.TestMode = false;

var input = Input.SplitAsInt(',');

//Part 1
var computer = new IntCodeComputer(input, 12, 2);
computer.Run();
Output.Answer(computer[0]);

var a = 0;
var b = 0;
var target = 19690720;

while (true)
{
    computer = new IntCodeComputer(input, a, b);
    computer.Run();
    if (computer[0] == target)
    {
        Output.Answer(100 * a + b);
        break;
    }

    computer = new IntCodeComputer(input, b, a);
    computer.Run();
    if (computer[0] == target)
    {
        Output.Answer(100 * b + a);
        break;
    }

    a++;
    if(a > b)
    {
        b++;
        a = 0;
    }
}