using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Proces1);
            Thread thread2 = new Thread(Proces2);
            Console.WriteLine("Start");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //Proces1();
            //Proces2();
            thread1.Priority = ThreadPriority.Lowest;
            thread2.Priority = ThreadPriority.Highest;
            thread1.Start();
            
            thread2.Start();
            thread1.Join();
            Console.WriteLine("End");
        }
        public static void Proces1()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (int i = 10; i <= 50; i++)
            {
                Console.WriteLine($"Threading 1: {i}");
            }
        }
        public static void Proces2()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (int i = 70; i <= 90; i++)
            {
                Console.WriteLine($"Threading 2: {i}");
            }
        }
    }
    
    
}
