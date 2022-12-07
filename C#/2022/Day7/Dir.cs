using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Dir
    {
        public string Name { get; set; }
        public Dir Parent { get; set; }

        public List<Dir> SubDirectories { get; set; } = new List<Dir>();
        public Dictionary<string, int> Files { get; set; } = new Dictionary<string, int>();

        public int Size()
        {
            var size = Files.Values.Sum();
            var subSize = SubDirectories.Select(x => x.Size()).Sum();
            return size + subSize;
        }

        public int Size(string dir)
        {
            if(Name == dir)
                return Size();
            else 
                return SubDirectories.Select(x => x.Size(dir)).Sum();
        }

        public int Part1()
        {
            var sum = 0;
            var size = Size();

            if (size <= 100000)
                sum += size;

            sum += SubDirectories.Select(x => x.Part1()).Sum();

            return sum;
        }

        public List<int> Sizes()
        {
            List<int> list = new List<int> { Size() };

            foreach (var sub in SubDirectories)
                list.AddRange(sub.Sizes());

            return list;
        }
    }
}
