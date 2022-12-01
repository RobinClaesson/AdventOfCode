namespace AoC.IO
{
    public class Input
    {
        public static bool TestMode
        {
            get => usedFile == TestFile;

            set
            {
                if (value)
                    usedFile = TestFile;
                else
                    usedFile = InputFile;
            }

        }

        private const string InputFile = "Input.txt";
        private const string TestFile = "Test.txt";

        private static string usedFile = InputFile;

        public static string All
        {
            get
            {
                return File.ReadAllText(usedFile);
            }
        }

        public static int AllAsInt
        {
            get
            {
                return int.Parse(All);
            }
        }

        public static List<string> Rows
        {
            get
            {
                return File.ReadLines(usedFile).ToList();
            }
        }

        public static List<int> RowsAsInt
        {
            get
            {
                return File.ReadLines(usedFile).Where(r => r != "").Select(r => int.Parse(r)).ToList();
            }
        }

        public static List<string> Split(char separator)
        {
            return All.Split(separator).ToList();
        }

        public static List<int> SplitAsInt(char separator)
        {
            return All.Split(separator).Select(s => int.Parse(s)).ToList();
        }

    }
}