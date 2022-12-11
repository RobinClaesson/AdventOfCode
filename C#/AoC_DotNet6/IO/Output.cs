using System.Numerics;

namespace AoC.IO
{
    public class Output
    {
        private static int outputs = 0;

        private static void CopyAndPrint(string answer)
        {
            Console.WriteLine($"Answer {++outputs}: {answer}");

            if (!Input.TestMode)
                TextCopy.ClipboardService.SetText(answer);
        }

        public static void Answer(string answer)
        {
            CopyAndPrint(answer);
        }

        public static void Answer(int answer)
        {
            CopyAndPrint($"{answer}");
        }

        public static void Answer(long answer)
        {
            CopyAndPrint($"{answer}");
        }
    }
}