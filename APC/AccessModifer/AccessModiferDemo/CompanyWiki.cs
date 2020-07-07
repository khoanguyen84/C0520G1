using System;
using System.Collections.Generic;
using System.Text;

namespace AccessModiferDemo
{
    class CompanyWiki
    {
        public static string CompanyPhoneNumber = "02343-123456";

        public static string MaskBankAccount(string bankAccount)
        {
            return $"{bankAccount.Substring(0, bankAccount.Length - 3)}XXX";
        }
    }
}
