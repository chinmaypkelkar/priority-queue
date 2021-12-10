using System;

namespace priority_queue_nuget
{
    public class MinHeap<T> where T : IComparable<T>
    {
        public MinHeap()
        {
            Head = null;
            Length = 0;
        }

        public int Length { get; set; } // length of heap
        public Node<T> Head { get; set; } // head 

        // method to insert and upheapify in heap
        public void Insert(T data)
        {
            var newNode = GetNextLocation(data);
            UpHeapify(newNode);
        }

        // get next location of the node where to insert it in heap
        private Node<T> GetNextLocation(T data)
        {
            var newNode = new Node<T>(data);
            if (Head is null)
            {
                Head = newNode;
            }
            else
            {
                var current = Head;
                var binary = ConvertToBinary(Length + 1); // get binary representation of current length + 1
                foreach (var item in binary
                ) // iterate through binary representation string to determine where to insert node
                    if (item == '0')
                    {
                        if (current.LeftChild != null) // if current node has left child, move current to left child
                        {
                            current = current.LeftChild;
                        }
                        else
                        {
                            newNode.Parent = current; // attach new node to current
                            current.LeftChild = newNode;
                        }
                    }
                    else
                    {
                        if (current.RightChild != null) // if current node has right child, move current to right child
                        {
                            current = current.RightChild;
                        }
                        else
                        {
                            newNode.Parent = current; // attach new node to current
                            current.RightChild = newNode;
                        }
                    }
            }

            Length++;
            return newNode;
        }

        // method to restore heap order via upheap bubbling
        private void UpHeapify(Node<T> currentNode)
        {
            while (currentNode != Head && currentNode.Data.CompareTo(currentNode.Parent.Data) < 0
            ) // loop through heap till currentnode is not root and currentnode's data is less than its parent
            {
                Swap(currentNode, currentNode.Parent);
                currentNode = currentNode.Parent;
            }
        }

        // method to get recently added node, swap it with root and rearrange heap to satisfy min heap ordering property
        public void Delete()
        {
            if (IsLeaf(Head)) // checks if head a last node i.e leaf node
            {
                Head = null;
                Length--;
                return;
            }
            GetCurrentNewest();
            DownHeapify();
        }

        // method to find recently added node and swap it's data with root
        private void GetCurrentNewest()
        {
            var current = Head;
            if (IsLeaf(current)) // if leaf node, no need to go ahead in the function
                return;
            var binaryNumber = ConvertToBinary(Length); // get binary representation of current length
            foreach (var item in binaryNumber
            ) // iterate through binary representation string to get recently added node
                if (item == '0')
                {
                    if (current?.LeftChild != null) // if current node has left child, move current to left child
                        current = current.LeftChild;
                }
                else
                {
                    if (current?.RightChild != null) // if current node has right child, move current to right child
                        current = current.RightChild;
                }
            

            if (binaryNumber[^1] == '0'
            ) // if last character in the string is 0 then swap current with root of heap and detach currentnode from heap
            {
                Swap(current, Head);
                var parent = current?.Parent;
                if (parent != null)
                    parent.LeftChild = null; // as last character is 0, we need to detach left child 

                if (current != null) current.Parent = null;
            }
            else // if last character in the string is 1 then swap current with root of heap and detach currentnode from heap
            {
                Swap(current, Head);
                var parent = current?.Parent;
                if (parent != null)
                    parent.RightChild = null; // as last character is 1, we need to detach right child 

                if (current != null)
                    current.Parent = null;
                
            }

            if (Length > 0)
                Length--;
            else
                throw new Exception("Nothing to delete");
        }

        // method to restore heap order via downheap bubbling 
        private void DownHeapify()
        {
            var current = Head;
            while (!IsLeaf(current) && current?.LeftChild?.Data.CompareTo(current.Data) < 0 || current?.RightChild?.Data.CompareTo(current.Data) < 0
            ) // loop through heap till currentnode is not leaf and we find less priority data in current's children 
            {
                var leftChild = current.LeftChild;
                var rightChild = current.RightChild;
                Node<T> nodeToBeSwapped = null;
                if (leftChild == null)
                {
                    nodeToBeSwapped = rightChild;
                }

                if (rightChild == null)
                {
                    nodeToBeSwapped = leftChild;
                }

                if (leftChild != null && rightChild != null)
                {
                    nodeToBeSwapped = leftChild.Data.CompareTo(rightChild.Data) > 0 
                            ? rightChild
                            : leftChild; // if left child has less priority than right child select left child for swapping or select right child
                }
               
                Swap(current, nodeToBeSwapped); // data swap
                current = nodeToBeSwapped; // move current to the child which got swapped
            }
        }

        // swap node data
        private static void Swap(Node<T> firstNode, Node<T> secondNode)
        {
            var temp = firstNode.Data;
            firstNode.Data = secondNode.Data;
            secondNode.Data = temp;
        }

        // method to determine if node is leaf or not
        private static bool IsLeaf(Node<T> node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }
        
        // method to convert input to binary and skip first character
        private static string ConvertToBinary(int length)
        {
            return Convert.ToString(length, 2).Substring(1);
        }
        
    }
}