using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Ultilities
{
    public static class Common
    {
        public static string apiUrl = @"https://localhost:44393/api";

        public enum Table
        {
            Course = 1,
            Teacher = 2,
            Module = 3,
            Student = 4
        }
    }

}
