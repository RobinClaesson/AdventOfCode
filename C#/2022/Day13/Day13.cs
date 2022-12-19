using AoC.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;

Input.TestMode = false;
var input = Input.Rows;

var pairs = new List<JArray[]>();
var arrays = new List<JArray>();

for (int i = 0; i < input.Count; i += 3)
{
    var left = JArray.Parse(input[i]);
    var right = JArray.Parse(input[i + 1]);
    pairs.Add(new JArray[] { left, right });

    arrays.Add(left);
    arrays.Add(right);
}


int part1 = 0;
for (int i = 0; i < pairs.Count; i++)
{
    if (Compare(pairs[i][0], pairs[i][1]) == CompRes.Right)
        part1 += i + 1;
}

Output.Answer(part1);

var packet1 = JArray.Parse("[[2]]");
var packet2 = JArray.Parse("[[6]]");
arrays.Add(packet1);
arrays.Add(packet2);
arrays.Sort(delegate (JArray j1, JArray j2) 
{
    return Compare(j1, j2) == CompRes.Right ? -1 : 1;
});

Output.Answer((arrays.IndexOf(packet1) + 1) * (arrays.IndexOf(packet2) + 1));

CompRes Compare(JToken left, JToken right)
{

    //Both are arrays
    if (left.Type == JTokenType.Array && right.Type == JTokenType.Array)
    {
        var leftArray = left.ToArray();
        var rightArray = right.ToArray();
        int i = 0;

        while (true)
        {
            //Both arrays run out at the same time
            if (leftArray.Length == i && rightArray.Length == i)
                return CompRes.Continue;

            //Only left runs out
            if (leftArray.Length == i)
                return CompRes.Right;

            //Only right array runs out
            if (rightArray.Length == i)
                return CompRes.Wrong;


            //Compare the elements 
            var comp = Compare(leftArray[i], rightArray[i]);

            if (comp != CompRes.Continue)
                return comp;

            i++;

        }
    }

    //Left is array but not right
    else if (left.Type == JTokenType.Array)
    {
        return Compare(left, new JArray(right));
    }

    //Right is array but not left
    else if (right.Type == JTokenType.Array)
    {
        return Compare(new JArray(left), right);
    }

    //Both are int
    else
    {

        var leftValue = left.Value<int>();
        var rightValue = right.Value<int>();

        if (leftValue == rightValue)
            return CompRes.Continue;

        if (leftValue < rightValue)
            return CompRes.Right;

        return CompRes.Wrong;
    }

}

enum CompRes { Right, Wrong, Continue }