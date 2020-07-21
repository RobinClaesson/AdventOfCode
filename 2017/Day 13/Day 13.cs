using AoC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> input = IO.InputRowsSplitted_Int(':');

            //Part 1
            List<int> ranges = new List<int>();
            foreach (int[] row in input)
            {
                while (ranges.Count < row[0])
                    ranges.Add(0);

                ranges.Add(row[1]);
            }

            int severitySum = 0;
            for (int i = 0; i < ranges.Count; i++)
            {
                if (i % RoundTrip(ranges[i]) == 0)
                    severitySum += i * ranges[i];
            }

            IO.Output(severitySum);

            //Part 2
            bool gotThrough = false;
            int hold = 0;

            while (!gotThrough)
            {
                gotThrough = true;
                for (int i = 0; i < ranges.Count; i++)
                {
                    if (ranges[i] != 0)
                        if ((i + hold) % RoundTrip(ranges[i]) == 0)
                        {
                            gotThrough = false;
                            break;
                        }
                }

                if (!gotThrough)
                    hold++;
            }


            IO.Output(hold, true);
            Console.ReadKey();
        }

        private static int RoundTrip(int range)
        {
            return (range - 1) * 2;
        }
    }
}
