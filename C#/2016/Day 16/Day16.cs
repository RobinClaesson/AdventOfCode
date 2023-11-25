using AoC.IO;
using System.Text;

Input.TestMode = false;
var input = Input.All;
FindCheckSum(272, input);
FindCheckSum(35651584, input);

void FindCheckSum(int diskSize, string input)
{
    var data = new String(input);
    while (data.Length < diskSize)
    {
        var sb = new StringBuilder(data);
        sb.Append("0");
        for (int i = data.Length - 1; i >= 0; i--)
            sb.Append(data[i] == '0' ? '1' : '0');

        data = sb.ToString();
    }
    data = data.Substring(0, diskSize);

    while (data.Length % 2 == 0)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < data.Length; i += 2)
            sb.Append(data[i] == data[i + 1] ? "1" : "0");

        data = sb.ToString();
    }

    Output.Answer(data);
}