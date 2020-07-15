using System;

namespace CleanCodeDemo
{
    class Program
    {
        //public const string AdditionalOperand = "+";
        //public const string SubtractOperand = "-";
        //public const string MultipleOperand = "x";
        //public const string DivisionOperand = ":";

        static void Main(string[] args)
        {
            Console.Write("Enter number 1: ");
            int number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter number 2: ");
            int number2 = int.Parse(Console.ReadLine());
            Console.Write("Enter operand: ");
            string operand = Console.ReadLine();
            if(operand == Operand.Addition)
            {
                Console.WriteLine($"{number1} {operand} {number2} = {Operator(number1, number2, operand)}");
            }
            else if (operand == Operand.Subtraction)
            {
                Console.WriteLine($"{number1} {operand} {number2} = {Operator(number1, number2, operand)}");
            }
            else if (operand == Operand.Multiple)
            {
                Console.WriteLine($"{number1} {operand} {number2} = {Operator(number1, number2, operand)}");
            }
            else if (operand == Operand.Division)
            {
                Console.WriteLine($"{number1} {operand} {number2} = {Operator(number1, number2, operand)}");
            }
            else
            {
                Console.WriteLine("Invalid operand");
            }
        }

        public static int Additional(int number1, int number2)
        {
            return number1 + number2;
        }
        public static int Substraction(int number1, int number2)
        {
            return number1 - number2;
        }
        public static int Mulitple(int number1, int number2)
        {
            return number1 * number2;
        }
        public static int Division(int number1, int number2)
        {
            return number1 / number2;
        }

        public static int Operator(int number1, int number2, string operand)
        {
            switch (operand)
            {
                case Operand.Addition:
                    {
                        return number1 + number2;
                    }
                case Operand.Subtraction:
                    {
                        return number1 - number2;
                    }
                case Operand.Multiple:
                    {
                        return number1 * number2;
                    }
                case Operand.Division:
                    {
                        return number1 / number2;
                    }
                default:
                    {
                        return -1;
                    }
            }
        }
    }
}
