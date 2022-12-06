using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Tools
{
    public class Extractor
    {
        /// <summary>
        /// Gets all the integers in a string with sections separated by a char
        /// </summary>
        /// <param name="input">string to extract ints from</param>
        /// <param name="separator">separator to split the string by</param>
        /// <returns>Array of all integers in the string</returns>
        public static int[] GetIntsInString(string input, char separator)
        {
            return input.Split(separator).Where(
                s => int.TryParse(s, out int n)
                ).Select(s => int.Parse(s)).ToArray();
        }

    }
}
