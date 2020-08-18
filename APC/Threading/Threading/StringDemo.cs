using System;
using System.Collections.Generic;
using System.Text;

namespace Threading
{
    class StringDemo
    {
        public static void Main()
        {
            string str = "CodeGym";
            var ch = str[0];

            StringBuilder sb = new StringBuilder(str);
            sb[0] = 'c';
        }
    }
}
