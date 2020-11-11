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
            Module = 2,
            Teacher = 3,
            Student = 4
        }
        public enum Gender
        {          
            Famale, 
            Male
        }
    }

}
