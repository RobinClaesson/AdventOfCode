using AoC.IO;

List<string> input = Input.Rows;

//Part 1
string message1 = "";
string message2 = "";
for (int x = 0; x < input[0].Length; x++)
{
    //Counts letters
    List<Letter> letters = new List<Letter>();
    for (int y = 0; y < input.Count; y++)
    {
        char c = input[y][x];

        bool hasChar = false;

        for (int k = 0; k < letters.Count; k++)
        {
            if (letters[k].c == c)
            {
                letters[k].n++;
                hasChar = true;
            }
        }

        if (!hasChar)
        {
            letters.Add(new Letter(c));
        }
    }

    //Finds the most common and least common
    Letter m = letters[0];
    Letter l = letters[0];

    for (int i = 1; i < letters.Count; i++)
    {
        if (letters[i].n > m.n)
            m = letters[i];

        else if (letters[i].n < l.n)
            l = letters[i];
    }

    message1 += m.c;
    message2 += l.c;
}

Output.Answer(message1);
Output.Answer(message2);


class Letter
{
    public char c;
    public int n;

    public Letter(char c)
    {
        this.c = c;
        n = 1;
    }
}