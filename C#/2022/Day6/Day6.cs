using AoC.IO;

Input.TestMode = false;
var input = Input.All;

int p1 = -1, p2 = -1;

for (int i = 0; i < input.Length; i++)
{
    if (p1 == -1)
    {
        var sub = input.Substring(i, 4).Distinct();
        if (sub.Count() == 4)
        {
            p1 = i + 4;
        }
    }

    if(p2 == -1)
    {
        var sub = input.Substring(i, 14).Distinct();
        if (sub.Count() == 14)
        {
            p2 = i + 14;
        }
    }
}

Output.Answer(p1);
Output.Answer(p2);
