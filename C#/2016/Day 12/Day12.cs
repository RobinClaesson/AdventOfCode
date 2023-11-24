using AoC.IO;

Input.TestMode = false;

var input = Input.RowsSplitted(' ');

RunInput(input, new() { { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 } });
RunInput(input, new() { { "a", 0 }, { "b", 0 }, { "c", 1 }, { "d", 0 } });

void RunInput(List<string[]> input, Dictionary<string, int> registers)
{

    for (int pc = 0; pc < input.Count; pc++)
    {
        var instruction = input[pc][0];
        var arg1 = input[pc][1];
        switch (instruction)
        {
            case "inc":
                registers[arg1]++;
                break;
            case "dec":
                registers[arg1]--;
                break;
            case "cpy":
                registers[input[pc][2]] = GetValue(arg1, registers);
                break;
            case "jnz":
                if (GetValue(arg1, registers) != 0)
                {
                    pc += GetValue(input[pc][2], registers);
                    pc--;
                }
                break;
        }
    }

    Output.Answer(registers["a"]);
}

int GetValue(string arg, Dictionary<string, int> registers)
{
    if (int.TryParse(arg, out var parsedVal))
        return parsedVal;
    else
        return registers[arg];
}