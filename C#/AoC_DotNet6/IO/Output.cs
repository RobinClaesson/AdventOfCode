namespace AoC.IO
{
    public class Output
    {
        private static int outputs = 0; 

        public static void Answer(string answer)
        {
            Console.WriteLine($"Answer {++outputs}: {answer}");
        }

        public static void Answer(int answer)
        {
            Console.WriteLine($"Answer {++outputs}: {answer}");
        }

        public static void Answer(long answer)
        {
            Console.WriteLine($"Answer {++outputs}: {answer}");
        }
    }
}
