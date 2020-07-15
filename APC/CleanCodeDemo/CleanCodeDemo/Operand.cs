using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeDemo
{
    struct Operand
    {
        public const string Addition = "+";
        public const string Subtraction = "-";
        public const string Multiple = "*";
        public const string Division = "/";

        public override string ToString()
        {
            return base.ToString();
        }
    }


}
