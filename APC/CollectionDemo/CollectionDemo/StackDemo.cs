using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionDemo
{
    class StackDemo
    {
        public static void Main()
        {
            Stack stack = new Stack();
            stack.Push(3);
            stack.Push(4);
            stack.Push(2);
            stack.Push(7);
            stack.Push(6);

            var pos = 0;
            while(pos < stack.Count)
            {
                Console.WriteLine(stack.Peek());
                pos++;
            }
        }
    }
}
