using AoC.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;

Input.TestMode = false;

var md5Hash = MD5.Create();
var input = Input.All;
var foundKeys = 0;
var addHashIndex = 0;
var currentIndex = -1;

//Part 1
var hashes = new List<string>();
for (int i = 0; i < 1001; i++)
    hashes.Add(GetNextHash());

while (foundKeys < 64)
{
    hashes.Add(GetNextHash());
    currentIndex++;
    if (HasTriplet(hashes[currentIndex], out var c))
    {
        var match = QuintetOfCharExists(c, currentIndex + 1);
        if (match != -1)
        {
            foundKeys++;
            //Console.WriteLine($"Nr {foundKeys}: {hashes[currentIndex]} at {currentIndex} Matches with: {hashes[match]} at {match}");
        }
    }
}

Output.Answer(currentIndex);

//Part 2
hashes.Clear();
currentIndex = -1;
addHashIndex = 0;
foundKeys = 0;

for (int i = 0; i < 1001; i++)
    hashes.Add(GetNextStretchedMD5Hash());

while (foundKeys < 64)
{
    hashes.Add(GetNextStretchedMD5Hash());
    currentIndex++;
    if (HasTriplet(hashes[currentIndex], out var c))
    {
        var match = QuintetOfCharExists(c, currentIndex + 1);
        if (match != -1)
        {
            foundKeys++;
            //Console.WriteLine($"Nr {foundKeys}: {hashes[currentIndex]} at {currentIndex} Matches with: {hashes[match]} at {match}");
        }
    }
}

Output.Answer(currentIndex);



bool HasTriplet(string hash, out char tripletChar)
{

    for (int i = 0; i < hash.Length - 2; i++)
    {
        if (hash[i] == hash[i + 1] && hash[i] == hash[i + 2])
        {
            tripletChar = hash[i];
            return true;
        }
    }

    tripletChar = ' ';
    return false;
}

int QuintetOfCharExists(char quintetChar, int startIndex)
{
    for (int i = startIndex; i < startIndex + 1000; i++)
    {
        if (hashes[i].Contains($"{quintetChar}{quintetChar}{quintetChar}{quintetChar}{quintetChar}"))
            return i;
    }
    return -1;
}

string GetMD5Hash(string salt)
{
    StringBuilder hash = new StringBuilder();
    byte[] bytes = md5Hash.ComputeHash(new UTF8Encoding().GetBytes(salt));

    for (int i = 0; i < bytes.Length; i++)
    {
        hash.Append(bytes[i].ToString("x2"));
    }

    return hash.ToString();
}

string GetNextHash()
{
    return GetMD5Hash($"{input}{addHashIndex++}");
}

string GetNextStretchedMD5Hash()
{
    var hash = GetNextHash();

    for(int i = 0; i < 2016; i++)
    {
        hash = GetMD5Hash(hash);
    }

    return hash;
}
