using System;

namespace AccessModiferDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Company phone number: " + CompanyWiki.CompanyPhoneNumber);
            Console.WriteLine(string.Format("Company Bank account: {0}, Phone number: {1}", 
                                CompanyWiki.MaskBankAccount("123-456-789"),
                                CompanyWiki.CompanyPhoneNumber));
            Console.WriteLine($"Company bank account: {CompanyWiki.MaskBankAccount("123-456-789")}," +
                                $" Phone number: {CompanyWiki.CompanyPhoneNumber}");
            //Math
            //Random
        }
    }
}
