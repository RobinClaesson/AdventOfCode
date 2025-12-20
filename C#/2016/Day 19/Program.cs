using AoC.IO;
using AoC.Extensions;
using Day19;

Input.TestMode = false;
var input = Input.AllAsInt;

//Part 1
var current = CreateElves(input)[0];
while (current.Next != current)
{
    current.Next.Remove();
    current = current.Next;
}

Output.Answer(current.Number);

//Part 2
var elves = CreateElves(input);
current = elves[0];
var remainingElfCount = elves.Count;
var opposite = elves[remainingElfCount / 2];

//We know from the example that when we have 5 left the elf after the starting point wins
//This removes handling edge cases for small circles  
while (remainingElfCount > 5)
{
    // PrintCircle(current, opposite);
    var nextOpposite = remainingElfCount % 2 == 0
        ? opposite.Next
        : opposite.Next.Next;
    
    opposite.Remove();
    opposite = nextOpposite;
    remainingElfCount--;

    current = current.Next;
}

Output.Answer(current.Next.Number);


return;

List<Elf> CreateElves(int count)
{
    var created = Enumerable.Range(1, count)
        .Select(i => new Elf(i))
        .ToList();

    created.ForEach(e =>
    {
        var index = e.Number - 1;
        e.Next = created[(index + 1).Mod(created.Count)];
        e.Previous = created[(index - 1).Mod(created.Count)];
    });

    return created;
}

void PrintCircle(Elf start, Elf? mark = null)
{
    var currentElf = start;
    var defaultColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Yellow;
    do
    {
        if (currentElf == mark)
            Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"{currentElf!.Number} > ");

        Console.ForegroundColor = defaultColor;

        currentElf = currentElf!.Next;
    } while (currentElf != start);

    Console.WriteLine();
}