using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    class Generator
    {
        long factor, value;
        int divider = 2147483647, multipleOf;


        public Generator(long factor, long startValue)
        {
            this.factor = factor;
            this.value = startValue;
            multipleOf = 1;
        }

        public Generator(long factor, long startValue, int multipleOf)
        {
            this.factor = factor;
            this.value = startValue;
            this.multipleOf = multipleOf;
        }

        public virtual long NextNumber()
        {
            do
            {
                value = (value * factor) % divider;
            } while (value % multipleOf != 0);

            return value;
        }
    }
}
