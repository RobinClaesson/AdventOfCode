using System.Numerics;

namespace AoC.IO
{
    public class Output
    {
        private static int outputs = 0;

        public static void Answer<T>(T answer)
        {
            Console.WriteLine($"Answer {++outputs}: {answer}");

            if (!Input.TestMode)
                TextCopy.ClipboardService.SetText($"{answer}");
        }

        
    }
}