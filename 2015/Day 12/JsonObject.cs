using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Day_12
{
    class JsonObject
    {
        List<JsonObject> jsonObjects = new List<JsonObject>();
        string value;

        public JsonObject(string source)
        {
            List<int> splitpoints = new List<int>();
            int open = 0, close = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == '{' || source[i] == '[')
                    open++;
                else if (source[i] == '}' || source[i] == ']')
                    open--;

                else if (source[i] == ',' && close == (open - 1))
                {
                    splitpoints.Add(i);
                }
            }

            if (splitpoints.Count > 0)
            {
                jsonObjects.Add(new JsonObject(source.Substring(1, splitpoints[0] - 1)));

                for (int i = 1; i < splitpoints.Count; i++)
                {
                    jsonObjects.Add(new JsonObject(source.Substring(splitpoints[i - 1] + 1, splitpoints[i] - splitpoints[i - 1] - 1)));
                }
            }

            else value = source;
        }
    }
}
