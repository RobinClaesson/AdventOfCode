using AoC.IO;

var input = Input.Rows.Select(s => s.ToCharArray()).ToList();
var input2 = Input.Rows;


Part1(input2);
Part2(input2);

//Part 2
List<char[]> oxygen = new List<char[]>();
oxygen.AddRange(input);
for (int x = 0; x < oxygen[0].Length; x++)
{
    int ones = 0, zeroes = 0;
    for (int y = 0; y < oxygen.Count; y++)
    {
        if (oxygen[y][x] == '0')
            zeroes++;
        else
            ones++;
    }
    if (ones >= zeroes)
    {
        for (int i = 0; i < oxygen.Count; i++)
            if (oxygen[i][x] == '0')
                oxygen.RemoveAt(i--);
    }

    else
    {
        for (int i = 0; i < oxygen.Count; i++)
            if (oxygen[i][x] == '1')
                oxygen.RemoveAt(i--);
    }

    if (oxygen.Count == 1)
        break;
}


List<char[]> co2 = new List<char[]>();
co2.AddRange(input);
for (int x = 0; x < co2[0].Length; x++)
{
    int ones = 0, zeroes = 0;
    for (int y = 0; y < co2.Count; y++)
    {
        if (co2[y][x] == '0')
            zeroes++;
        else
            ones++;
    }

    if (ones >= zeroes)
    {
        for (int i = 0; i < co2.Count; i++)
            if (co2[i][x] == '1')
                co2.RemoveAt(i--);
    }

    else
    {
        for (int i = 0; i < co2.Count; i++)
            if (co2[i][x] == '0')
                co2.RemoveAt(i--);
    }

    if (co2.Count == 1)
        break;
}

Output.Answer(Convert.ToInt32(new string(oxygen[0]), 2) * Convert.ToInt32(new string(co2[0]), 2));

static void Part1(List<string> input)
{

    string least = "", most = "";

    for (int i = 0; i < input[0].Length; i++)
    {
        int ones = (from x in input where x[i] == '1' select x).Count();

        if (ones > input.Count / 2)
        {
            most += '1';
            least += '0';
        }

        else
        {
            most += '0';
            least += '1';
        }
    }

    Output.Answer(Convert.ToInt32(most, 2) * Convert.ToInt32(least, 2));
}

static void Part2(List<string> input)
{
    List<string> oxygen = new List<string>();
    oxygen.AddRange(input);
    List<string> co2 = new List<string>();
    co2.AddRange(input);

    int i = 0;
    while (oxygen.Count() > 1 || co2.Count() > 1)
    {
        if (oxygen.Count() > 1)
        {
            var temp = oxygen.GroupBy(x => x[i]).OrderByDescending(g => g.Count());
            oxygen = oxygen.GroupBy(x => x[i]).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).Select(g => g.ToList()).First();
        }

        if (co2.Count() > 1)
            co2 = co2.GroupBy(x => x[i]).OrderBy(g => g.Count()).Select(g => g.ToList()).First();

        i++;
    }

}

