using AoC.IO;

Input.TestMode = false;
var input = Input.RowsSplitted(' ');

//Part 1
var sizes = input.Select(r => int.Parse(r[3])).ToList();
var positions = input.Select(r => int.Parse(r.Last().Replace(".", ""))).ToList();
FindTimeForButtonPress(positions, sizes);

//Part2
sizes.Add(11);
positions = input.Select(r => int.Parse(r.Last().Replace(".", ""))).ToList();
positions.Add(0);
FindTimeForButtonPress(positions, sizes);

void FindTimeForButtonPress(List<int> positions, List<int> sizes)
{
    //Set all disks to the value they will have when the capsule gets there 
    for (int i = 0; i < sizes.Count; i++)
    {
        positions[i] += 1 + i;
        positions[i] %= sizes[i];
    }

    var capsuleGetsThroughIndex = 0;
    while (positions.Any(p => p != 0))
    {
        capsuleGetsThroughIndex++;
        for (int i = 0; i < sizes.Count; i++)
        {
            positions[i]++;
            positions[i] %= sizes[i];
        }
    }

    Output.Answer(capsuleGetsThroughIndex);
}