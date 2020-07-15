using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionDemo
{
    class QueueDemo
    {
        public static void Main()
        {
            Queue queue = new Queue();
            queue.Enqueue(2);
            queue.Enqueue(12);
            queue.Enqueue(22);
            queue.Enqueue(3);
            queue.Enqueue(10);
            
            while(queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine(queue.Count);
        }
    }
}
