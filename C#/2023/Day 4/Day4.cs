using AoC.IO;

Input.TestMode = false;

var input = Input.Rows.Select(r => r.Split(':')[1].Split('|').Select(s => s.Split(' ').Where(s => s != string.Empty).Select(s => int.Parse(s)).ToArray()).ToArray()).ToList();

var winning = input.Select(r => r[1].Where(i => r[0].Contains(i)).Count()).ToList();

Output.Answer(winning.Sum(w => w == 0 ? 0 : Math.Pow(2, w-1)));

var cards = winning.Select(w => new int[] {w, 1}).ToList();

for (int i = 0; i < cards.Count; i++)
{
    for (int j = 1; j <= cards[i][0]; j++)
    {
        cards[i + j][1] += cards[i][1];
    }
}

Output.Answer(cards.Sum(c => c[1]));