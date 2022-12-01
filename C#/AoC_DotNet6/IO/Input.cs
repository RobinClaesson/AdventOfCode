namespace AoC.IO
{
    public class Input
    {
        public static string All
        {
            get
            {
                return File.ReadAllText("Input.txt");
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
                return File.ReadLines("Input.txt").ToList();
            }
        }

        public static List<int> RowsAsIt
        {
            get
            {
                return Rows.Where(r => r != "").Select(r => int.Parse(r)).ToList();
            }
        }

        public static List<string> Split(char separator)
        {
            string input = All;

            return input.Split(separator).ToList();
        }
    }
}