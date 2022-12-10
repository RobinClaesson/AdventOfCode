using AoC.IO;

Input.TestMode = false;
var input = Input.Rows;

var sum = 0;
var register = 1;

var countAt = new int[] { 20, 60, 100, 140, 180, 220 };
int pc = 0;

for (int i = 1; i <= 240; i++)
{
    //Part 1

    var info = input[pc].Split(' ');

    //1st cycle
    CycleCheck(i);

    if (info[0] == "addx")
    {
        i++;
        //2nd cycle
        CycleCheck(i);

        register += int.Parse(info[1]);
    }

    pc++;
}

Console.WriteLine();
Output.Answer(sum);

void CycleCheck(int i)
{
    if (countAt.Contains(i))
    {
        sum += register * i;
        //Console.WriteLine($"{i} * {register}");

    }

    int x = (i - 1) % 40; 
    char c = Math.Abs(x - register) < 2 ? '#' : '.';
    Console.Write(c);

    if (i % 40 == 0)
        Console.WriteLine();
}