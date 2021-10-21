using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    class Node
    {
        int[] metadata;
        Node[] children;

        //Public constructor that starts from the begining and calls a
        //private constructor that can move the index
        public Node(string[] info) : this(info, 0)
        {

        }

        private Node(string[] info, int index)
        {
            //Calculate sizes
            int numOfChildren = int.Parse(info[index++]);
            int numOfMetadata = int.Parse(info[index++]);

            children = new Node[numOfChildren];
            metadata = new int[numOfMetadata];

            //Adds children
            for (int i = 0; i < numOfChildren; i++)
            {
                children[i] = new Node(info, index);

                index += children[i].InfoLength;
            }

            //Adds metadata
            for (int i = 0; i < numOfMetadata; i++)
            {
                metadata[i] = int.Parse(info[index++]);
            }
        }

        /// <summary>
        /// Returns the size the node takes in the info string including its children
        /// /// </summary>
        private int InfoLength
        {
            get
            {
                //Header + metadata size
                int size = metadata.Length + 2;

                //Children size
                foreach (Node child in children)
                    size += child.InfoLength;

                return size;
            }
        }
        /// <summary>
        /// Returns the sum of a node and all its childrens metadata (Part 1)
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = metadata.Sum();

                foreach (Node child in children)
                    sum += child.Sum;

                return sum;
            }
        }
        /// <summary>
        /// Sum dependent on if the node has children or not (Part 2)
        /// </summary>
        public int Sum2
        {
            get
            {
                if (children.Length == 0)
                    return metadata.Sum();


                int sum = 0;
                for (int i = 0; i < metadata.Length; i++)
                {
                    int index = metadata[i]-1;

                    if (index >= 0 && index < children.Length)
                        sum += children[index].Sum2;
                }
                return sum;
            }
        }
    }
}
