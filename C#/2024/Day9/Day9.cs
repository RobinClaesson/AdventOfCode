using AoC.IO;

Input.TestMode = false;

var input = Input.AllCharsAsInts;

var files = new List<int>();

var id = 0;
for (int i = 0; i < input.Count; i++)
{
    var content = i % 2 == 0 ? id++ : -1;
    var file = Enumerable.Repeat(content, input[i]).ToArray();
    files.AddRange(file);
}

var fromIndex = files.Count - 1;
var toIndex = files.FindIndex(f => f == -1);
do
{
    //PrintFiles();
    files[toIndex] = files[fromIndex];
    files[fromIndex] = -1;

    toIndex++;
    fromIndex--;

    if (files[toIndex] != -1)
        toIndex = files.FindIndex(toIndex + 1, f => f == -1);
    if (files[fromIndex] == -1)
        fromIndex = files.FindLastIndex(fromIndex - 1, f => f != -1);

} while (fromIndex > toIndex);

Output.Answer(CalcChecksum(files));


//Part2
files.Clear();
id = 1; //Id's shifted by 1 for easier removal of filled voids, changed back before checksum calculation
for (int i = 0; i < input.Count; i++)
{
    if (i % 2 == 0)
    {
        var file = Enumerable.Repeat(id++, input[i]).ToArray();
        files.AddRange(file);
    }
    else if (input[i] > 0)
    {
        files.Add(-1 * input[i]);
    }

}

var filesToCheck = files.Where(f => f > 0)
                        .Distinct()
                        .OrderDescending()
                        .ToList();

foreach (var fileId in filesToCheck)
{
    //Console.WriteLine($"Moving {fileId}");

    var currFileStart = files.FindIndex(f => f == fileId);
    var currFileEnd = files.LastIndexOf(fileId);
    var currFileLength = currFileEnd - currFileStart + 1;
    var currFile = files.GetRange(currFileStart, currFileLength);

    var target = files.FindIndex(f => f < 0 && f <= -currFileLength);
    if (target != -1 && target < currFileStart)
    {
        files[target] += currFileLength;

        files.RemoveRange(currFileStart, currFileLength);
        files.Insert(currFileStart, -currFileLength);
        files.InsertRange(target, currFile);

        files = files.Where(f => f != 0).ToList(); //Remove filled voids
    }
}

for (int i = 0; i < files.Count; i++)
{
    //Reset Id-shift
    if (files[i] > 0)
        files[i]--;

    // Expand voids to match the original file lengths
    // Fill voids with 0's to not fill the voids again
    else if (files[i] < 0)
    {
        var length = files[i] * -1;
        files.RemoveAt(i);
        files.InsertRange(i, Enumerable.Repeat(0, length));
    }
}

Output.Answer(CalcChecksum(files));

long CalcChecksum(List<int> files) => files.Select((f, i) => f == -1 ? 0L : f * i).Sum();
void PrintFiles(List<int> files)
{
    foreach (var file in files)
    {
        var output = file < 0 ? string.Join("", Enumerable.Repeat('.', file * -1)) : $"{file}";
        Console.Write(output);
    }
    Console.WriteLine();
}