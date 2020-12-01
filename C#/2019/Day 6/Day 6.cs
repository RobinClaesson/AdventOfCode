using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = IO.InputRows;
            //List<string> input = Input.GetInputList_String;

            List<Node> nodes = new List<Node>();

            //Adding nodes
            foreach (string row in input)
            {
                string parentID = row.Split(')')[0];
                string childID = row.Split(')')[1];

                Node childNode = null;

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].id == childID)
                    {
                        childNode = nodes[i];
                        nodes.RemoveAt(i);
                        break;
                    }
                }

                if (childNode == null)
                    childNode = new Node(childID);

                bool addedNode = false;
                foreach (Node node in nodes)
                {
                    if (node.HasNodeInTree(parentID))
                    {
                        node.AddNodeToTree(childNode, parentID);
                        addedNode = true;

                    }

                }


                if (!addedNode)
                {
                    Node node = new Node(parentID);
                    node.AddNodeToTree(childNode, parentID);
                    nodes.Add(node);
                }
            }


            IO.Output(nodes[0].Weight());
            IO.Output(nodes[0].StepsBetween("YOU", "SAN"));


        }
    }
}
