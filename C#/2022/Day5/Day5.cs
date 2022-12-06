using AoC.IO;
using AoC.Tools;

Input.TestMode = false;
var input = Input.Rows;

var spitPoint = input.IndexOf("");
var crateInfo = input.GetRange(0, spitPoint - 1);
var moves = input.GetRange(spitPoint + 1, input.Count - spitPoint - 1);

var cratesP1 = new List<List<char>>();
var cratesP2 = new List<List<char>>();
for (int x = 1; x < crateInfo[0].Length; x += 4)
{
    var crateStack = crateInfo.Select(s => s[x]).Where(c => c != ' ').Reverse().ToList();
    cratesP1.Add(crateStack);
    cratesP2.Add(new List<char>(crateStack));
}


foreach (var move in moves)
{
    int[] moveInfo = Extractor.GetIntsInString(move, ' ');

    //P1
    var moveFrom = cratesP1[moveInfo[1] - 1];
    var toMove = moveFrom.GetRange(moveFrom.Count - moveInfo[0], moveInfo[0]);
    moveFrom.RemoveRange(moveFrom.Count - moveInfo[0], moveInfo[0]);
    toMove.Reverse();
    cratesP1[moveInfo[2] - 1].AddRange(toMove);

    //P2
    moveFrom = cratesP2[moveInfo[1] - 1];
    toMove = moveFrom.GetRange(moveFrom.Count - moveInfo[0], moveInfo[0]);
    moveFrom.RemoveRange(moveFrom.Count - moveInfo[0], moveInfo[0]);
    cratesP2[moveInfo[2] - 1].AddRange(toMove);
}

var part1 = new string(cratesP1.Select(x => x.Last()).ToArray());
Output.Answer(part1);
var part2 = new string(cratesP2.Select(x => x.Last()).ToArray());
Output.Answer(part2);
