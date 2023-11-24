using AoC.IO;

string input = Input.All;

Output.Answer(Decompress(input, false).Length);
Output.Answer(DecompressedLengthImproved(input));


string Decompress(string input, bool decompressCompressed)
{
    for (int i = 0; i < input.Length; i++)
    {
        //The start of a decompression
        if (input[i] == '(')
        {
            //Finds the end of the decomp isntruction
            int j = i;
            do
            {
                j++;
            } while (input[j] != ')');

            string[] values = input.Substring(i + 1, j - i - 1).Split('x');

            int numOfChars = int.Parse(values[0]);
            int times = int.Parse(values[1]);

            string toCopy = input.Substring(j + 1, numOfChars);
            int copyLength = toCopy.Length;

            if (decompressCompressed)
                toCopy = Decompress(toCopy, true);

            string toInsert = "";

            for (int k = 0; k < times; k++)
                toInsert += toCopy;

            string beforeInstruction = input.Substring(0, i);
            string afterInstruction = input.Substring(j + 1 + copyLength);

            input = beforeInstruction + toInsert + afterInstruction;

            i += toInsert.Length - 1;
        }
    }

    return input;
}

long DecompressedLengthImproved(string input)
{
    //If there is no ( we dont need to decompress and the answer is just the length
    if (!input.Contains("("))
        return input.Length;


    long length = 0;
    for (int i = 0; i < input.Length; i++)
    {
        //The start of a decompression
        if (input[i] == '(')
        {
            //Finds the end of the decomp isntruction
            int j = i;
            do
            {
                j++;
            } while (input[j] != ')');

            string instruction = input.Substring(i + 1, j - i - 1);
            string[] values = instruction.Split('x');

            int numOfChars = int.Parse(values[0]);
            int times = int.Parse(values[1]);

            string toCopy = input.Substring(j + 1, numOfChars);

            long copyLength = DecompressedLengthImproved(toCopy);
            copyLength *= times;

            length += copyLength;
            i += numOfChars + instruction.Length + 1;
        }

        else length++;
    }

    return length;

}