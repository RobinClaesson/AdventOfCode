using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    class Node
    {
        private List<Node> children = new List<Node>();
        public string id;

        public Node(string id)
        {
            this.id = id;
        }

        public bool HasNodeInTree(string nodeID)
        {
            if (nodeID == id)
                return true;

            bool hasChild = false;


            foreach (Node child in children)
            {
                if (child.id == nodeID || child.HasNodeInTree(nodeID))
                    hasChild = true;
            }

            return hasChild;
        }



        public void AddNodeToTree(Node newChild, string parentID)
        {
            if (parentID == id)
                children.Add(newChild);

            else
            {
                foreach (Node child in children)
                    child.AddNodeToTree(newChild, parentID);
            }
        }

        public int Weight()
        {
            return (Weight(0));
        }

        private int Weight(int depth)
        {
            int w = 0;
            foreach (Node child in children)
                w += child.Weight(depth + 1);

            return depth + w;
        }

        public int StepsBetween(string child1ID, string child2ID)
        {
            if (!HasNodeInTree(child1ID) || !HasNodeInTree(child2ID))
                return -1;

            Node parent = ClosestComonParent(child1ID, child2ID);


            return parent.StepsToChild(child1ID, 0) + parent.StepsToChild(child2ID, 0);

        }

        public Node ClosestComonParent(string child1ID, string child2ID)
        {
            Node node = this;

            foreach (Node child in children)
                if (child.HasNodeInTree(child1ID) && child.HasNodeInTree(child2ID))
                    node = child.ClosestComonParent(child1ID, child2ID);


            return node;
        }


        public int StepsToChild(string childID, int stepsTaken)
        {
            if (childID == id)
                return stepsTaken - 1;


            else
            {
                int steps = 0;
                foreach (Node child in children)
                    if (child.HasNodeInTree(childID))
                        steps += child.StepsToChild(childID, stepsTaken + 1);

                return steps;
            }
        }
    }
}
