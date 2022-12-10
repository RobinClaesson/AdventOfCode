using AoC.IO;

var fishes = Input.SplitAsInt(',');

long[] days = new long[7];
long[] newSpawn = new long[7];
int currentDay = 0;

//Adds init state 
for (int i = 0; i < 7; i++)
    days[i] = fishes.Count(f => f == i);

for (int i = 0; i < 80; i++)
{
    int spawnsAt = (currentDay + 2 + days.Length) % days.Length;
    newSpawn[spawnsAt] = days[currentDay];

    days[currentDay] += newSpawn[currentDay];
    newSpawn[currentDay] = 0;

    currentDay = (1 + currentDay + days.Length) % days.Length;
}

Output.Answer(days.Sum() + newSpawn.Sum());

//Part 2 
for (int i = 0; i < 176; i++)
{
    int spawnsAt = (currentDay + 2 + days.Length) % days.Length;
    newSpawn[spawnsAt] = days[currentDay];

    days[currentDay] += newSpawn[currentDay];
    newSpawn[currentDay] = 0;

    currentDay = (1 + currentDay + days.Length) % days.Length;
}
long p2 = days.Sum();
p2 += newSpawn.Sum();

Output.Answer(p2);