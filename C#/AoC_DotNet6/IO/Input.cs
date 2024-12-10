namespace AoC.IO
{
    public class Input
    {
        public static bool TestMode
        {
            get => fileToRead == TestFile;

            set
            {
                if (value)
                    fileToRead = TestFile;
                else
                    fileToRead = InputFile;
            }

        }

        private const string InputFile = "Input.txt";
        private const string TestFile = "Test.txt";

        private static string fileToRead = InputFile;

        public static string All 
            => File.ReadAllText(fileToRead);

        public static int AllAsInt
            => int.Parse(All);

        public static List<int> AllCharsAsInts
            => All.Select(c => c - '0').ToList();

        public static List<string> Rows 
            => File.ReadLines(fileToRead)
                .ToList();

        public static List<int> RowsAsInt
            => File.ReadLines(fileToRead)
                .Where(r => r != "")
                .Select(r => int.Parse(r))
                .ToList();

        public static List<List<int>> RowsAsIndividualInts
            => File.ReadLines(fileToRead)
                .Where(r => r != "")
                .Select(r => r.Select(c => int.Parse($"{c}")).ToList())
                .ToList();

        public static List<List<int>> IntGrid 
            => File.ReadLines(fileToRead)
                .Select(r => r.Select(c => int.Parse($"{c}")).ToList())
                .ToList();

        public static List<string> Split(char separator)
            => All
                .Split(separator)
                .ToList();

        public static List<string[]> RowsSplitted(char separator)
            => File.ReadLines(fileToRead)
                .Select(s => s.Split(separator))
                .ToList();

        public static List<string[]> RowsSplitted(string separator)
            => File.ReadLines(fileToRead)
                .Select(s => s.Split(separator))
                .ToList();

        public static List<int[]>RowsSplittedAsInt(char separator)
            => File.ReadLines(fileToRead)
                .Select(s => s.Split(separator)
                .Where(s => s != string.Empty)
                .Select(s => int.Parse(s)).ToArray())
                .ToList();

        public static List<int[]> RowsSplittedAsInt(string separator)
            => File.ReadLines(fileToRead)
                .Select(s => s.Split(separator)
                .Where(s => s != string.Empty)
                .Select(s => int.Parse(s)).ToArray())
                .ToList();

        public static List<int> SplitAsInt(char separator)
            => All.Split(separator)
                .Select(s => int.Parse(s))
                .ToList();
    }
}