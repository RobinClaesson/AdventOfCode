using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = IO.Input.Split(' ');

            Node root = new Node(input);

            IO.Output(root.Sum);
            IO.Output(root.Sum2);

            Console.ReadKey();
        }
    }
}
