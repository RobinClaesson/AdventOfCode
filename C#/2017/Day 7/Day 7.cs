using AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;

            List<Node> nodes = new List<Node>();

            //Adds all nodes to the list
            foreach (string row in input)
            {
                string[] words = row.Split(' ');
                nodes.Add(new Node(words[0], int.Parse(words[1].Split('(')[1].Split(')')[0])));
            }


            //Structures the nodes into the tree
            foreach (string row in input)
            {
                if (row.Contains("->"))
                {
                    string[] childNames = row.Split('>')[1].Replace(" ", "").Split(',');
                    string parentName = row.Split(' ')[0];

                    foreach (string childName in childNames)
                    {
                        int childIndex = 0;
                        while (childIndex < nodes.Count)
                        {
                            if (nodes[childIndex].Name == childName)
                                break;

                            childIndex++;
                        }

                        Node child = nodes[childIndex];
                        nodes.RemoveAt(childIndex);


                        foreach (Node node in nodes)
                        {
                            node.AddChildToTree(child, parentName);
                        }
                    }
                }
            }

            Node root = nodes[0];
            IO.Output(root.Name, false);

            IO.Output(root.NewWeightOfUnbalanced());

            Console.ReadKey();

        }
    }
}
