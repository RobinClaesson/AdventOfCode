using AoC.IO;

Input.TestMode = false;

var input = Input.RowsAsInt;

var part1 = input.Select(x => x/3 - 2).Sum();
Output.Answer(part1);