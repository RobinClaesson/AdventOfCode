using AoC.IO;
using AoC.Tools;

Input.TestMode = false;
var input = Input.Rows;

var itemsP1 = new List<Queue<ulong>>(); //List of lists of items each monkey has
var itemsP2 = new List<Queue<ulong>>(); //List of lists of items each monkey has
var operations = new List<Func<ulong, ulong>>(); //List of the operation functions each monkey has 
var tests = new List<Func<ulong, int>>(); //Returns the monkey to throw the item to
var inspections = new List<long>(); //List of the times monkeys inspects items
ulong multOfAll = 1;

for (int i = 1; i < input.Count; i += 7)
{
    //Staring items
    var items = Extractor.GetIntsInString(input[i].Split(':')[1].Replace(" ", ""), ',').Select(i => (ulong)i);
    itemsP1.Add(new Queue<ulong>(items));
    itemsP2.Add(new Queue<ulong>(items));

    // Operation
    var opValue = input[i + 1].Split(' ').Last();
    if (input[i + 1][23] == '+')
    {
        if (ulong.TryParse(opValue, out ulong res))
            operations.Add((item) => item + res);
        else
            operations.Add((item) => item + item);
    }
    else
    {
        if (ulong.TryParse(opValue, out ulong res))
            operations.Add((item) => item * res);
        else
            operations.Add((item) => item * item);
    }

    //Test
    var testValue = ulong.Parse(input[i + 2].Split(' ').Last());
    var ifTrue = int.Parse(input[i + 3].Split(' ').Last());
    var ifFalse = int.Parse(input[i + 4].Split(' ').Last());

    tests.Add((item) => (item % testValue) == 0 ? ifTrue : ifFalse);
    multOfAll *= testValue;

    //Init inspections to 0
    inspections.Add(0);
}


//P1
for (int r = 1; r <= 20; r++)
{
    for (int m = 0; m < itemsP1.Count; m++)
    {
        while (itemsP1[m].Count > 0)
        {
            var item = itemsP1[m].Dequeue();
            item = operations[m](item) / 3;

            var nextMonkey = tests[m](item);
            itemsP1[nextMonkey].Enqueue(item);

            inspections[m]++;
        }
    }
}

var p1 = inspections.OrderByDescending(i => i).ToArray();
Output.Answer(p1[0] * p1[1]);

//Reset inspections 
for (int i = 0; i < inspections.Count; i++)
    inspections[i] = 0;

int[] logAt = { 1, 20, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };
//Part 2
for (int r = 1; r <= 10000; r++)
{
    for (int m = 0; m < itemsP2.Count; m++)
    {
        while (itemsP2[m].Count > 0)
        {
            var item = itemsP2[m].Dequeue();
            var opItem = operations[m](item % multOfAll);

            var nextMonkey = tests[m](opItem);


            itemsP2[nextMonkey].Enqueue(opItem);

            inspections[m]++;
        }
    }

    if (logAt.Contains(r))
    {
        Console.Write($"Round {r}:\t\t [");
        foreach (var s in inspections)
            Console.Write($"{s}, ");
        Console.WriteLine("]");
    }
}

var p2 = inspections.OrderByDescending(i => i).ToArray();
Output.Answer(p2[0] * p2[1]);
