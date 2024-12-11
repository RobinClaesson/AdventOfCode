using AoC.IO;

Input.TestMode = false;

var input = Input.SplitAsInt(' ');

var stones = input.ToDictionary(i => (long)i, i => 1L);

string s = string.Empty;

DoIterations(stones, 25);
Output.Answer(SumStones(stones));
DoIterations(stones, 50);
Output.Answer(SumStones(stones));

void DoIterations(Dictionary<long, long> stones, long iterations)
{
    for (long i = 0; i < iterations; i++)
    {
        var nextIteration = new Dictionary<long, long>();
        foreach ((var stone, var count) in stones)
        {
            if (stone == 0)
            {
                AddStone(nextIteration, 1, count);
            }
            else if ((s = $"{stone}").Length % 2 == 0)
            {
                AddStone(nextIteration, long.Parse(s.Substring(0, s.Length / 2)), count);
                AddStone(nextIteration, long.Parse(s.Substring(s.Length / 2)), count);
            }
            else
            {
                AddStone(nextIteration, stone * 2024, count);
            }
        }
        stones = nextIteration;
    }
}

long SumStones(Dictionary<long, long> stones)
{
    return stones.Sum(s => s.Value);
}

void AddStone(Dictionary<long, long> stones, long stone, long count)
{
    if (stones.ContainsKey(stone))
        stones[stone] += count;
    else
        stones[stone] = count;
}

void PrintStones(Dictionary<long, long> stones)
{
    foreach ((var stone, var count) in stones)
    {
        Console.Write($"{stone}: {count} | ");
    }
    Console.WriteLine();
}