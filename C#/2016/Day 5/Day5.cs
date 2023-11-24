using AoC.IO;
using System.Security.Cryptography;
using System.Text;

//string input = IO.Input;
var input = Input.All;

MD5 md5Hash = MD5.Create();


int passwordLength = 8;
string password1 = "";
char[] password2 = "--------".ToCharArray();

//Part 1
int i = 0;

Console.WriteLine("Finding password 1: 0/" + passwordLength);
while (password1.Length < passwordLength)
{
    string hash = MD5Hash(input + i, md5Hash);

    if (hash.Substring(0, 5) == "00000")
    {
        password1 += hash[5];

        Console.WriteLine("Finding password 1: " + password1.Length + "/" + passwordLength);
    }

    i++;
}

//Part 2
i = 0;
int found = 0;
Console.WriteLine("Finding password 2: 0/" + passwordLength);
while (found < passwordLength)
{
    string hash = MD5Hash(input + i, md5Hash);

    if (hash.Substring(0, 5) == "00000")
    {
        try
        {
            int pos = int.Parse(hash[5] + "");

            if (pos < password2.Length)
                if (password2[pos] == '-')
                {
                    password2[pos] = hash[6];

                    found++;
                    Console.WriteLine("Finding password 2: " + found + "/" + passwordLength);
                }
        }
        catch { }
    }

    i++;
}

Output.Answer(password1);
Output.Answer(new string(password2));

string MD5Hash(string input, MD5 md5Hash)
{
    //https://coderwall.com/p/4puszg/c-convert-string-to-md5-hash
    //https://www.reddit.com/r/adventofcode/comments/3vdn8a/day_4_solutions/cxmt6yp?utm_source=share&utm_medium=web2x

    StringBuilder hash = new StringBuilder();
    //MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
    byte[] bytes = md5Hash.ComputeHash(new UTF8Encoding().GetBytes(input));

    for (int i = 0; i < bytes.Length; i++)
    {
        hash.Append(bytes[i].ToString("x2"));
    }
    return hash.ToString();
}