using System;
using System.Text;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] arr1 = {1,2,3,4,5};
            // int[] arr2 = new int[5];
            // int[] arr3 = new int[5]{5,6,7,8,9};

            // Random rnd = new Random();
            // for(int i=0; i< arr2.Length; i++){
            //     arr2[i] = rnd.Next(10,50);
            // }

            // PrintArray(arr1);
            // PrintArray(arr2);
            // PrintArray(arr3);
            // for(int i=0; i< arr1.Length; i++){
            //     Console.Write(arr1[i] + ", ");
            // }
            // Console.WriteLine();
            // for(int i=0; i< arr2.Length; i++){
            //     Console.Write(arr2[i] + ", ");
            // }
            // Console.WriteLine();
            // for(int i=0; i< arr3.Length; i++){
            //     Console.Write(arr3[i] + ", ");
            // }
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            // int[] arr4 = new int[0];
            // string key = "C";
            // do{
            //     Console.Write("Nhập số: ");
            //     int num = int.Parse(Console.ReadLine());
            //     Array.Resize(ref arr4, arr4.Length + 1);
            //     arr4[arr4.Length-1] = num;
            //     Console.Write("Bạn có muốn tiếp tục không? (C/K): ");
            //     key = Console.ReadLine();
            // }
            // while(key.ToUpper() != "K");
            //PrintArray(arr4);
            // Console.WriteLine();
            // for(int i=0; i< arr4.Length; i++){
            //     Console.Write(arr4[i] + ", ");
            // }
            // Console.WriteLine("Mảng bạn vửa tạo là:" + PrintArray2(arr4));

            int[] a = GenerateArray(10);
            Console.WriteLine("Mảng có 10 phần tử là:" + PrintArray2(a));

            Console.Write("Nhập vào kích cỡ mảng bạn muốn tạo: ");
            int size = int.Parse(Console.ReadLine());
            int[] b = GenerateArray(size, 100, 200);
            Console.WriteLine("Mảng có "+size+" phần tử là:" + PrintArray2(b));

        }

        public static void PrintArray(int[] arr){
            for(int i=0; i< arr.Length; i++){
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }

        public static string PrintArray2(int[] arr){
            string str ="";
            for(int i=0; i< arr.Length; i++){
                str = str + arr[i] + ", ";
            }
            return str;
        }

        public static int[] GenerateArray(int size, int min = 10, int max = 50){
            int[] arr = new int[size];
            Random rnd = new Random();
            for(int i=0; i< arr.Length; i++){
                arr[i] = rnd.Next(min,max);
            }

            return arr;
        }
    }
}
