using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    public class Helper
    {
        public static int Min(int[] numbers)
        {
            if (numbers.Length == 0)
                return int.MinValue;

            int min = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
            }

            return min;
        }

        public static int Max(int[] numbers)
        {
            if (numbers.Length == 0)
                return int.MaxValue;

            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i];
            }

            return max;
        }
    }
}
