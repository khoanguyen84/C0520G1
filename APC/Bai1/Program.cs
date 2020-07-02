using System;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            object n1 = 10;
            Console.WriteLine(5 + (int)n1);
            dynamic n2 = 15;
            Console.WriteLine(5 + n2);

            int a = 5;
            int b = 6;
            var c = "7";
            var d = '7';
            Console.WriteLine(a + b + c);
            Console.WriteLine(a + b + d);
            Console.WriteLine((int)d);

            double dtb = 5.6;
            int xepLoai = 0;
            if(dtb >= 9){
                xepLoai = 1;
            }
            else if(dtb >=8){
                xepLoai = 2;
            }
            else{
                xepLoai = 3;
            }

            switch(xepLoai){
                case 1:{
                    Console.WriteLine("Xuất sắc");
                    break;
                }
                case 2:{
                    break;
                }
                case 3:{
                    break;
                }
                default:{
                    Console.WriteLine("Bó tay");
                    break;
                }

            }

            for(int i = 0; i< 10; i++){
                Console.Write(i + ", ");
            }
            Console.WriteLine();
            for(int i = 9; i>= 0;i--){
                Console.Write(i + ", ");
            }
        }
    }
}
