using System;
using System.Net.Http.Json;

namespace priority_queue_nuget
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Test case 1
            var priorityQueue = new PriorityQueue<string>();
            priorityQueue.Enqueue("asdasd");
            priorityQueue.Enqueue("asdas");
            priorityQueue.Enqueue("kjnakjsd");
            priorityQueue.Enqueue("asdasd");

            var dequeuedNode = priorityQueue.Dequeue();
            Console.WriteLine("Node removed is {0}",dequeuedNode);
            dequeuedNode = priorityQueue.Dequeue();
            Console.WriteLine("Node removed is {0}",dequeuedNode);
            dequeuedNode = priorityQueue.Dequeue();
            Console.WriteLine("Node removed is {0}",dequeuedNode);
            
            Console.WriteLine("asdb asdasd  asdkas dI am testing if my typing fixed and see if it has any problem with test");


            Console.WriteLine("I am writing this after turning off the graphics mode");
           
            //Test case 2
            /*var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue(6);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(4);
            priorityQueue.Enqueue(3);

            var dequeuedNode = priorityQueue.Dequeue();
            Console.WriteLine("Node removed is {0}",dequeuedNode);
            dequeuedNode = priorityQueue.Dequeue();
            Console.WriteLine("Node removed is {0}",dequeuedNode);
            dequeuedNode = priorityQueue.Dequeue();
            Console.WriteLine("Node removed is {0}",dequeuedNode);
            dequeuedNode = priorityQueue.Dequeue();
            Console.WriteLine("Node removed is {0}",dequeuedNode);*/

            //Test case 3
            /*var priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue(6);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(11);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(9);
            priorityQueue.Enqueue(4);
            
            Console.WriteLine("Peek returns {0}",priorityQueue.Peek());
            priorityQueue.Search(4);
            priorityQueue.Search(10);*/
        }
    }
}