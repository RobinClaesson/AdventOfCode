using AoC.IO;

Input.TestMode = false;
var input = Input.IntGrid;

Output.Answer(input.Select(bank => GetMaxJoltages(bank, 2)).Sum());
Output.Answer(input.Select(bank => GetMaxJoltages(bank, 12)).Sum());
return;

long GetMaxJoltages(List<int> bank, int batteryCount)
{
    if (batteryCount == 1)
        return bank.Max();

    if (bank.Count == batteryCount)
        return bank.Aggregate(0L, (acc, battery) => 10 * acc + battery);
    
    var current = bank.Take(bank.Count - batteryCount + 1).Max();
    var following = GetMaxJoltages(bank.Skip(bank.IndexOf(current) + 1).ToList(), batteryCount - 1);

    return long.Parse($"{current}{following}");
}