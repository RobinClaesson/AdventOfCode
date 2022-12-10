using AoC.IO;

var input = Input.All.Replace("\r\n", "¤").Split('¤');

const string MARKED = "X";

string[] numbers = input[0].Split(',');

List<string[][]> boards = new List<string[][]>();

for (int i = 2; i < input.Length; i += 6)
{
    string[][] board = new string[5][];
    for (int j = 0; j < 5; j++)
        board[j] = input[i + j].Split(' ').Where(s => s != "").ToArray(); //Splits and finters out empy strings

    boards.Add(board);
}


List<string[][]> winners = new List<string[][]>();
List<int> calledToWin = new List<int>();

for (int i = 0; i < numbers.Length; i++)
{
    foreach (string[][] board in boards)
    {
        if (!winners.Contains(board))
        {
            MarkBoard(board, numbers[i]);

            if (CheckWin(board))
            {
                winners.Add(board);
                calledToWin.Add(int.Parse(numbers[i]));
            }
        }
    }
}

Output.Answer(SumUnmarked(winners[0]) * calledToWin[0]);
Output.Answer(SumUnmarked(winners.Last()) * calledToWin.Last());

Console.ReadKey();


static void MarkBoard(string[][] board, string number)
{
    for (int y = 0; y < board.Length; y++)
        for (int x = 0; x < board[y].Length; x++)
            if (board[y][x] == number)
            {
                board[y][x] = MARKED;
            }

}

static bool CheckWin(string[][] board)
{
    //Horizontal
    for (int y = 0; y < board.Length; y++)
        if (board[y].Count(s => s == MARKED) == 5)
            return true;


    //Vertical
    for (int x = 0; x < board[0].Length; x++)
    {
        bool win = true;
        for (int y = 0; y < board.Length; y++)
        {
            if (board[y][x] != MARKED)
                win = false;
        }

        if (win)
            return true;
    }


    return false;
}

static int SumUnmarked(string[][] board)
{
    int sum = 0;

    for (int y = 0; y < board.Length; y++)
        for (int x = 0; x < board[y].Length; x++)
        {
            if (int.TryParse(board[y][x], out int unmarked))
                sum += unmarked;
        }

    return sum;
}
