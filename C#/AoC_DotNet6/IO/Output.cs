using System.Numerics;

namespace AoC.IO
{
    public class Output
    {
        private static int outputs = 0;

        public static void Answer<T>(T answer)
        {
            string text = $"Answer {++outputs}: {answer}";
            Console.WriteLine(text);

            if (!Input.TestMode)
                TextCopy.ClipboardService.SetText(text);
        }

        
    }
}