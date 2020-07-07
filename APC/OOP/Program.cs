using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Person khoa = new Person();
            // khoa.FullName = "Khoa Nguyen";
            // khoa.SetPinCode("12345-45678-567");
            // Console.WriteLine($"Fullname: {khoa.FullName}");
            // Console.WriteLine($"PinCode: {khoa.GetPinCode()}");

            Person nhan = new Person();
            nhan.FullName = "Nhan Nguyen";
            nhan.PinCode = "12345-45678-567";
            nhan.ITScore = (decimal)8.8;
            nhan.MathScore = (decimal)8.9;
            Console.WriteLine($"Fullname: {nhan.FullName}");
            Console.WriteLine($"PinCode: {nhan.PinCode}");
            Console.WriteLine($"Average Score' Nhan: {nhan.AverageScore}");
            var a = Helper.StringHelper.BankInfo;
        }
    }
}
