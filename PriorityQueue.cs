using System;

namespace priority_queue_nuget
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            Heap = new MinHeap<T>();
        }

        private MinHeap<T> Heap { get; } // heap 

        // method to enqueue data in the queue. Internally it calls insert 
        public void Enqueue(T data)
        {
            Heap.Insert(data);
        }

        // method to dequeue data from the queue. Internally it calls delete
        public T Dequeue()
        {
            var returnData = Heap.Head.Data;
            Heap.Delete();
            return returnData;
        }

        // get the front element of queue i.e head
        public T Peek()
        {
            return Heap.Head.Data;
        }

        // method to determine if queue is empty or not
        private bool IsEmpty()
        {
            return Heap.Length == 0;
        }
        
    }
}