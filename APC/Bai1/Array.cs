using System;
namespace Bai1
{
    class ArrayDemo
    {
        public static void Main()
        {
        
            // int[] a = {1,2,3,4,5};
            // int[] b = new int[5] {1,2,3,4,5};
            // PrintArray(a);
            // PrintArray(b);
            // Console.Write("Input your array size: ");
            // int size = int.Parse(Console.ReadLine());
            // int[] arr = GenerateArray(size);
            // PrintArray(arr);

            int[] arr2 = GenerateArray();
            PrintArray(arr2);

        }

        public static void PrintArray(int[] arr){
            for(int i = 0; i< arr.Length; i++){
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }

        public static int[] GenerateArray(int size){
            int[] arr = new int[size];
            Random rnd = new Random();
            for(int i=0; i< size; i++){
                arr[i] = rnd.Next(10,90);
            }
            return arr;
        }

        public static int[] GenerateArray()
        {
            int[] arr = new int[0];
            string key = "Y";
            do{
                Console.Write("Input your number: ");
                int val = int.Parse(Console.ReadLine());
                Array.Resize(ref arr, arr.Length + 1);
                arr[arr.Length - 1] = val;
                Console.Write("Press N to exit: ");
                key = Console.ReadLine();
            }
            while(string.Compare(key.ToUpper(),"N") != 0);

            return arr;
        }
    }
}