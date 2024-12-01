using AoC.IO;

Input.TestMode = false;

var input = Input.RowsSplittedAsInt("   ");

var left = input.Select(input => input[0]).Order().ToList();
var right = input.Select(input => input[1]).Order().ToList();

var part1 = 0;
for(int i = 0; i < left.Count; i++)
{
    part1 += Math.Abs(left[i] - right[i]); 
}
Output.Answer(part1);

var part2 = 0;
left.ForEach(l => part2 += l * right.Count(r => r == l));
Output.Answer(part2);