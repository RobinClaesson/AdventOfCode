using AoC.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

var md5Hash = MD5.Create();

var input = Input.All;
var position = new Vector2(0, 0);
var target = new Vector2(3, 3);

var queue = new Queue<(Vector2 room, string path)>();
queue.Enqueue((position, string.Empty));

//up, down, left, right
var directions = new Vector2[] { new Vector2(0, -1), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(1, 0) };
var pathDirections = new string[] { "U", "D", "L", "R" };

//Part 1
while (!queue.Any(x => x.room == target))
{
    var current = queue.Dequeue();
    var hash = GetMD5Hash($"{input}{current.path}");

    for (int i = 0; i < 4; i++)
    {
        if (hash[i] >= 'b' && hash[i] <= 'f')
        {
            var nextRoom = current.room + directions[i];

            if (nextRoom.X >= 0 && nextRoom.X <= 3 && nextRoom.Y >= 0 && nextRoom.Y <= 3)
            {
                queue.Enqueue((nextRoom, $"{current.path}{pathDirections[i]}"));
            }
        }
    }
}

Output.Answer(queue.First(x => x.room == target).path);

//Part 2
var paths = new List<string>();
while (queue.Count > 0)
{
    var current = queue.Dequeue();
    var hash = GetMD5Hash($"{input}{current.path}");

    for (int i = 0; i < 4; i++)
    {
        if (hash[i] >= 'b' && hash[i] <= 'f')
        {
            var nextRoom = current.room + directions[i];

            if (nextRoom == target)
            {
                paths.Add($"{current.path}{pathDirections[i]}");
            }
            else if (nextRoom.X >= 0 && nextRoom.X <= 3 && nextRoom.Y >= 0 && nextRoom.Y <= 3)
            {
                queue.Enqueue((nextRoom, $"{current.path}{pathDirections[i]}"));
            }

        }
    }
}

Output.Answer(paths.Max(p => p.Length));

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