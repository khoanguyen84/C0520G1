using System;

namespace ExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3] { 1, 2, 3 };
            try
            {
                Console.WriteLine("Divison example");
                int a = 10;
                int b = 0;
                //Console.WriteLine($"{a}/{b} = {a / b}");

                //Console.WriteLine(array[3]);

                //if (a == 10)
                    //throw new CustomException(a);
                    //throw new CustomException($"{a} khong phai la so nguyen to");

                B classB = new B();
                Console.WriteLine(classB.Sum(10, 0));
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(IndexOutOfRangeException e)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = 5;
            }
            catch(CustomException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception type: {e.GetType().Name}, Message: {e.Message}" );
            }
            finally
            {
                Console.WriteLine("End");
            }

            //Console.WriteLine(array[3]);
        }
    }

    public class CustomException : Exception
    {
        public CustomException(int number) : base($"{number} is not prime")
        {

        }

        public CustomException(string message) : base(message)
        {

        }
    }

    public class CreateEmployeeException : Exception
    {
        public CreateEmployeeException(string message) : base(message)
        {

        }
    }



    //nested exception
    public class A
    {
        public int Division(int a, int b)
        {
            return a / b;
        }
    }

    public class B : A
    {
        public int Sum(int a, int b)
        {
            return Division(a, b) + b;
        }
    }
}
