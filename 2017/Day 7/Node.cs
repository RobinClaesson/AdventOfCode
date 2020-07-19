using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Day_7
{
    class Node
    {
        int weight;
        string name;
        List<Node> childNodes = new List<Node>();



        public Node(string name, int weight)
        {
            this.weight = weight;
            this.name = name;
        }

        public int Weight { get { return weight; } set { weight = value; } }
        public string Name { get { return name; } set { name = value; } }

        public bool AddChildToTree(Node node, string parentName)
        {
            if (name == parentName)
            {
                childNodes.Add(node);
                return true;
            }

            else
            {
                bool added = false;

                foreach (Node child in childNodes)
                {
                    if (child.AddChildToTree(node, parentName))
                        added = true;
                }

                return added;
            }
        }

        public bool HasNodeInTree(string nodeName)
        {
            if (name == nodeName)
                return true;

            else
            {
                foreach (Node child in childNodes)
                    if (child.HasNodeInTree(nodeName))
                        return true;
            }

            return false;
        }

        public int TotalWeight
        {
            get
            {
                if (childNodes.Count == 0)
                    return weight;

                else
                    return weight + ChildWeight;

            }
        }

        public int ChildWeight
        {
            get
            {
                int sum = 0;

                foreach (Node child in childNodes)
                    sum += child.TotalWeight;

                return sum;
            }
        }

        public bool IsBalanced
        {
            get
            {
                if (childNodes.Count == 0)
                    return true;

                else
                {
                    int sum = 0;

                    foreach (Node child in childNodes)
                        sum += child.TotalWeight;

                    return sum == childNodes[0].TotalWeight * childNodes.Count;
                }
            }
        }



        private bool AllChildrenAreBalanced
        {
            get
            {
                foreach (Node child in childNodes)
                {
                    if (!child.IsBalanced)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public int NewWeightOfUnbalanced()
        {
            //If there is a unbalanced child the problem isn't at this level
            foreach (Node child in childNodes)
                if (!child.IsBalanced)
                    return child.NewWeightOfUnbalanced();


            //If we come this far one of our children are the target
            foreach (Node child in childNodes)
            {
                bool hasOther = false;

                foreach (Node other in childNodes)
                {
                    if (child.name != other.name && child.TotalWeight == other.TotalWeight)
                        hasOther = true;
                }

                //If no other child has the same weight as this child this is our target
                if (!hasOther)
                {
                    //the index of our child
                    int childIndex = childNodes.IndexOf(child);

                    //This sets our sibling index to 1 if childindex is 0, otherwise siblingindex is 1
                    int siblingIndex = 1;
                    if (childIndex > 0)
                        siblingIndex = 0;

                    return childNodes[siblingIndex].TotalWeight - child.ChildWeight;
                }
            }


            return -1;
        }


    }
}
