using AoC.IO;

Input.TestMode = false;

var input = Input.RowsSplitted(':');

var targets = input.Select(x => long.Parse(x[0])).ToList();
var terms = input.Select(x => x[1].Trim().Split(' ').Select(long.Parse).ToList()).ToList();

var hasPossible = targets.Where((t, i) => HasMatch(t, terms[i])).ToList();
Output.Answer(hasPossible.Sum());

hasPossible = targets.Where((t, i) => HasMatchPart2(t, terms[i])).ToList();
Output.Answer(hasPossible.Sum());

var a = 0;

static bool HasMatch(long target, List<long> numbers)
{
    var possibleResults = GetPossibleResults(numbers, target);
    return possibleResults.Contains(target);
}

static bool HasMatchPart2(long target, List<long> numbers)
{
    var possibleResults = GetPossibleResultsPart2(numbers, target);
    return possibleResults.Contains(target);
}

static List<long> GetPossibleResults(List<long> numbers, long target)
{
    if (numbers.Count == 1)
        return numbers.ToList();

    var plus = numbers[0] + numbers[1];
    var mult = numbers[0] * numbers[1];

    if (numbers.Count == 2)
        return new() { plus, mult };

    //No need to go deepser if we already surpassed target
    var possibleAfterPlus = plus <= target ? GetPossibleResults(new List<long> { plus }.Concat(numbers.Skip(2)).ToList(), target) : new();
    var possibleAfterMult = mult <= target ? GetPossibleResults(new List<long> { mult }.Concat(numbers.Skip(2)).ToList(), target) : new();

    return possibleAfterMult.Concat(possibleAfterPlus).ToList();
}

static List<long> GetPossibleResultsPart2(List<long> numbers, long target)
{
    if (numbers.Count == 1)
        return numbers.ToList();

    var plus = numbers[0] + numbers[1];
    var mult = numbers[0] * numbers[1];
    var concat = long.Parse($"{numbers[0]}{numbers[1]}");

    if (numbers.Count == 2)
        return new() { plus, mult, concat };

    //No need to go deepser if we already surpassed target
    var possibleAfterPlus = plus <= target ? GetPossibleResultsPart2(new List<long> { plus }.Concat(numbers.Skip(2)).ToList(), target) : new();
    var possibleAfterMult = mult <= target ? GetPossibleResultsPart2(new List<long> { mult }.Concat(numbers.Skip(2)).ToList(), target) : new();
    var possibleAfterConcat = concat <= target ? GetPossibleResultsPart2(new List<long> { concat }.Concat(numbers.Skip(2)).ToList(), target) : new();

    return possibleAfterMult.Concat(possibleAfterPlus).Concat(possibleAfterConcat).ToList();
}

