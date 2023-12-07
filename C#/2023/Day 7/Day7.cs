using AoC.IO;

Input.TestMode = false;

var input = Input.RowsSplitted(' ')
                .Select(r =>
                    new Hand(r[0],
                            int.Parse(r[1]))).ToList();

var rankedInput = input.OrderBy(h => GetHandType(h.Cards))
                    .ThenBy(h => RankCard(h.Cards[0]))
                    .ThenBy(h => RankCard(h.Cards[1]))
                    .ThenBy(h => RankCard(h.Cards[2]))
                    .ThenBy(h => RankCard(h.Cards[3]))
                    .ThenBy(h => RankCard(h.Cards[4])).ToList();

Output.Answer(Enumerable.Range(0, rankedInput.Count).Sum(i => (i + 1) * rankedInput[i].Bet));


var rankedInput2 = input.OrderBy(h => GetHandType2(h.Cards))
                    .ThenBy(h => RankCard2(h.Cards[0]))
                    .ThenBy(h => RankCard2(h.Cards[1]))
                    .ThenBy(h => RankCard2(h.Cards[2]))
                    .ThenBy(h => RankCard2(h.Cards[3]))
                    .ThenBy(h => RankCard2(h.Cards[4])).ToList();

Output.Answer(Enumerable.Range(0, rankedInput2.Count).Sum(i => (i + 1) * rankedInput2[i].Bet));


HandType GetHandType(string cards)
{
    var groups = cards.GroupBy(c => c);

    if (groups.Any(g => g.Count() == 5))
        return HandType.FiveOfAKind;

    if (groups.Any(g => g.Count() == 4))
        return HandType.FourOfAKind;

    if (groups.Any(g => g.Count() == 3))
    {
        if (groups.Any(g => g.Count() == 2))
            return HandType.FullHouse;

        return HandType.ThreeOfAKind;
    }

    if (groups.Where(g => g.Count() == 2).Count() == 2)
        return HandType.TwoPair;

    if (groups.Any(g => g.Count() == 2))
        return HandType.OnePair;

    return HandType.HighCard;
}

HandType GetHandType2(string cards)
{
    var possibleHands = new List<string>() { cards };

    for (char c = '1'; c <= '9'; c++)
    {
        possibleHands.Add(new string(cards).Replace('J', c));
    }
    possibleHands.Add(new string(cards).Replace('J', 'T'));
    possibleHands.Add(new string(cards).Replace('J', 'Q'));
    possibleHands.Add(new string(cards).Replace('J', 'K'));
    possibleHands.Add(new string(cards).Replace('J', 'A'));

    return possibleHands.Max(GetHandType);
}

int RankCard(char card)
{
    if (char.IsAsciiDigit(card))
        return int.Parse($"{card}");

    switch (card)
    {
        case 'T': return 10;
        case 'J': return 11;
        case 'Q': return 12;
        case 'K': return 13;
        case 'A': return 14;
    }

    return 0;
}

int RankCard2(char card)
{
    if (char.IsAsciiDigit(card))
        return int.Parse($"{card}");

    switch (card)
    {
        case 'T': return 10;
        case 'Q': return 12;
        case 'K': return 13;
        case 'A': return 14;
    }

    return 0;
}

record Hand(string Cards, int Bet);
enum HandType
{
    HighCard = 1,
    OnePair = 2,
    TwoPair = 3,
    ThreeOfAKind = 4,
    FullHouse = 5,
    FourOfAKind = 6,
    FiveOfAKind = 7,
}