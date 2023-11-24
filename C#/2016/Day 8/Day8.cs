using AoC.IO;

List<string> input = Input.Rows;

int sizeY = 6, sizeX = 50;
int[,] pixels = new int[sizeY, sizeX];

foreach (string instruction in input)
{
    if (instruction.Contains("rect"))
    {
        string[] values = instruction.Split(' ')[1].Split('x');

        int width = int.Parse(values[0]);
        int height = int.Parse(values[1]);

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                pixels[y, x] = 1;

    }

    else if (instruction.Contains("row"))
    {
        int row = int.Parse(instruction.Split(' ')[2].Split('=')[1]);
        int steps = int.Parse(instruction.Split(' ').Last());

        for (int i = 0; i < steps; i++)
        {
            int previuos = pixels[row, 0];
            pixels[row, 0] = pixels[row, sizeX - 1];

            for (int j = 1; j < sizeX; j++)
            {
                int current = pixels[row, j];
                pixels[row, j] = previuos;
                previuos = current;
            }


        }
    }

    else if (instruction.Contains("colum"))
    {
        int colum = int.Parse(instruction.Split(' ')[2].Split('=')[1]);
        int steps = int.Parse(instruction.Split(' ').Last());

        for (int i = 0; i < steps; i++)
        {
            int previuos = pixels[0, colum];
            pixels[0, colum] = pixels[sizeY - 1, colum];

            for (int j = 1; j < sizeY; j++)
            {
                int current = pixels[j, colum];
                pixels[j, colum] = previuos;
                previuos = current;
            }


        }
    }


}

int sum = 0;
foreach (int p in pixels)
    sum += p;

Output.Answer(sum);
Output.Answer(string.Empty);
PrintPixels(pixels, sizeX, sizeY);


void PrintPixels(int[,] pixels, int widht, int heigth)
{
    for (int y = 0; y < heigth; y++)
    {
        for (int x = 0; x < widht; x++)
        {
            if (pixels[y, x] > 0)
                Console.Write("#");
            else
                Console.Write(" ");
        }

        Console.WriteLine();
    }

}