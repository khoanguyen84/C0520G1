using System;

namespace SortAlgorithmDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 20;
            long startTime = DateTimeOffset.Now.Ticks;
            //Console.WriteLine($"{n}! = {GiaiThua(n)}"); --664809
            Console.WriteLine($"{n}! = {KDQGiaiThua(n)}");
            long endTime = DateTimeOffset.Now.Ticks;
            Console.WriteLine($"Total time to proces: {endTime - startTime}");
        }

        public static long GiaiThua(int n)
        {
            if (n == 1)
                return 1;
            return n * GiaiThua(n - 1);
        }

        public static long KDQGiaiThua(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            return result;
        }
    }
}
