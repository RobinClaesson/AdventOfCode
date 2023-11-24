using AoC.IO;

var input = Input.RowsSplitted('-');
Output.Answer(SumOfReal(input));
Output.Answer(SectorOfStore(input));

int SumOfReal(List<string[]> input)
{

    int sum = 0;
    foreach (string[] row in input)
    {
        List<Letter> letters = new List<Letter>();

        //Counts all the letters
        for (int i = 0; i < row.Length - 1; i++)
        {
            for (int j = 0; j < row[i].Length; j++)
            {
                char c = row[i][j];

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
                    Letter l = new Letter();
                    l.c = c;
                    l.n = 1;
                    letters.Add(l);
                }
            }
        }

        //Sorts by number first and alfabetical second
        for (int i = 0; i < letters.Count; i++)
        {
            int first = i;

            for (int j = i + 1; j < letters.Count; j++)
            {
                if (letters[j].n > letters[first].n)
                    first = j;

                else if (letters[j].n == letters[first].n && letters[j].c < letters[first].c)
                    first = j;

            }

            if (first != i)
            {
                Letter temp = new Letter();
                temp.c = letters[i].c;
                temp.n = letters[i].n;

                letters[i].c = letters[first].c;
                letters[i].n = letters[first].n;

                letters[first].c = temp.c;
                letters[first].n = temp.n;
            }
        }

        string fiveMost = "";
        for (int i = 0; i < 5; i++)
            fiveMost += letters[i].c;

        string checksum = row.Last().Substring(row.Last().IndexOf('[') + 1, 5);

        if (fiveMost == checksum)
            sum += int.Parse(row.Last().Split('[')[0]);
    }


    return sum;
}

int SectorOfStore(List<string[]> input)
{

    foreach (string[] row in input)
    {
        string decrypted = "";

        int sectorID = int.Parse(row.Last().Split('[')[0]);
        for (int i = 0; i < row.Length - 1; i++)
        {

            for (int j = 0; j < row[i].Length; j++)
            {

                decrypted += Rotate(row[i][j], sectorID);

            }

            decrypted += " ";
        }

        if (decrypted.Contains("north"))
            return sectorID;
    }



    return -1;
}

char Rotate(char c, int ammount)
{
    for (int i = 0; i < ammount; i++)
    {
        c++;

        if (c > 'z')
            c = 'a';
    }

    return c;
}

class Letter
{
    public char c;
    public int n;
}