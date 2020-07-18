using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    enum Type { Microchip, Generator };
    class Item
    {
        string element;
        Type type;

        public Item(Type type, string element)
        {
            this.type = type;
            this.element = element;
        }

        public Item(Item other)
        {
            this.type = other.type;
            this.element = other.element;
        }

        public string Element { get { return element; } }
        public Type Type { get { return type; } }
    }
}
