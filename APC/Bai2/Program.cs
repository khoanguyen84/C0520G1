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

            // int[] a = GenerateArray(10);
            // var result = FindMax2(a);
            // Console.WriteLine($"Max value is {result.MaxValue}, and the postion is {result.MaxPos}");
            // Console.WriteLine("Mảng có 10 phần tử là:" + PrintArray2(a));

            // Console.Write("Nhập vào kích cỡ mảng bạn muốn tạo: ");
            // int size = int.Parse(Console.ReadLine());
            // int[] b = GenerateArray(size, 100, 200);
            // Console.WriteLine("Mảng có "+size+" phần tử là:" + PrintArray2(b));

            // int num1 = 10;
            // int num2 = 20;
            // Swap(ref num1,ref num2);
            // Console.Write($"num 1: {num1}, num2 : {num2}");
            // int[] arr = GenerateArray(100);
            // PrintArray(arr);
            // Console.Write($"min value is: {FindMin(arr, out int pos)}, and position is: {pos}");
            Console.WriteLine($"{Sum(10)}");
            Console.WriteLine($"{Sum(10, 20)}");
        }

        public static int Sum(int a, int? b = null){
            if(b.HasValue){
                return a + b.Value;
            }
            return a;
        }
        public static void Swap(ref int a,ref int b){
            int t = a;
            a = b;
            b = t;
        }

        public static int FindMin(int[] arr, out int pos){
            int min = arr[0];
            int minPos = 0;
            for(int i = 1; i < arr.Length; i++){
                if(arr[i] < min){
                    min = arr[i];
                    minPos = i;
                }
            }
            pos = minPos;
            return min;
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

        public static int FindMax(int[] arr, out int pos){
            int max = arr[0];
            int maxPos = 0;
            for(int i=1; i<arr.Length; i++){
                if(arr[i] > max){
                    max = arr[i];
                    maxPos = i;
                }
            };
            pos = maxPos;
            return max;
        }

        public static Res FindMax2(int[] arr){
            var result = new Res(){
                MaxPos = -1,
                MaxValue = arr[0]
            };
            int max = arr[0];
            for(int i=1; i<arr.Length; i++){
                if(arr[i] > max){
                    result.MaxValue = arr[i];
                    result.MaxPos = i;
                }
            };
            return result;
        }
    }

    public class Res {
        public int MaxValue { get; set; } 
        public int MaxPos { get; set; }
    }
}
