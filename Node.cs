namespace priority_queue_nuget
{
    public class Node<T>
    {
        // initialize node
        public Node(T dataIn)
        {
            Data = dataIn;
            LeftChild = null;
            RightChild = null;
            Parent = null;
        }
        public T Data { get; set; } // stores data
        public Node<T> LeftChild { get; set; } // left child address
        public Node<T> RightChild { get; set; } // right child address
        public Node<T> Parent { get; set; } // parent address
        
    }
}