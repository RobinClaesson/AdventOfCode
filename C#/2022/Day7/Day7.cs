using AoC.IO;
using Day7;

Input.TestMode = false;
var input = Input.Rows;

var root = new Dir() { Name = "/" };
var current = root;

for (int i = 1; i < input.Count; i++)
{
    if (input[i] == "$ ls")
    {
        while (i + 1 < input.Count && !input[i+1].Contains("$"))
        {
            i++;
            var split = input[i].Split(' ');

            if (split[0] == "dir")
            {
                current.SubDirectories.Add(new Dir() { Name = split[1], Parent = current });
            }
            else
            {
                current.Files.Add(split[1], int.Parse(split[0]));
            }
        }
    }

    if (input[i].Contains("$ cd"))
    {
        var split = input[i].Split(' ');

        if (split[2] == "/")
            current = root;
        else if (split[2] == "..")
            current = current.Parent;
        else
            current = current.SubDirectories.Where(x => x.Name == split[2]).First();
    }
}

Output.Answer(root.Part1());

int free = 70000000 - root.Size();
int needToDelete = 30000000 - free;

Output.Answer(root.Sizes().Where(i => i > needToDelete).Min());


